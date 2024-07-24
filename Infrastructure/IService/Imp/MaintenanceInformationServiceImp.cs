using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseMainInformation;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceInformationServiceImp : IMaintenanceInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public MaintenanceInformationServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseMaintenanceInformation> Create(CreateMaintenanceInformation create)
        {
            var mi = _mapper.Map<MaintenanceInformation>(create);
            var email = _tokensHandler.ClaimsFromToken();
            mi.CreatedDate = DateTime.Now;
            var account = await _unitOfWork.Account.Profile(email);
            var customercare = await _unitOfWork.CustomerCare.GetById(account.CustomerCare.CustomerCareId);
            mi.CustomerCareId = customercare.CustomerCareId;

            if (mi.BookingId == null)
            {
                await _unitOfWork.InformationMaintenance.Add(mi);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(mi);
            }
            else
            {
                var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
                booking.Status = EnumStatus.ACCEPT.ToString();
                await _unitOfWork.InformationMaintenance.Add(mi);
                await _unitOfWork.Booking.Update(booking);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(mi);
            }
        }

        public async Task<ResponseMaintenanceInformation> CreateHaveItems(CreateMaintenanceInformationHaveItems create)
        {
            var mi = MapAndInitializeMaintenanceInformation(create);
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var customercare = await _unitOfWork.CustomerCare.GetById(account.CustomerCare.CustomerCareId);
            mi.CustomerCareId = customercare.CustomerCareId;

            var doublePrice = await ProcessSparePartInfos(mi.MaintenanceSparePartInfos, mi.InformationMaintenanceId, mi.TotalPrice);
            mi.TotalPrice = doublePrice;

            await ProcessServiceInfos(mi.MaintenanceServiceInfos, mi.InformationMaintenanceId, mi.TotalPrice);

            if (mi.BookingId == null)
            {
                return await HandleNullBookingId(mi);

            }
            return await HandleNonNullBookingId(mi);
        }

        public async Task<List<ResponseMaintenanceInformation>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceInformation>>(await _unitOfWork.InformationMaintenance.GetAll());
        }

        public async Task<ResponseMaintenanceInformation> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceInformation>(await _unitOfWork.InformationMaintenance.GetById(id));
        }

        private async Task<float> ProcessSparePartInfos(IEnumerable<MaintenanceSparePartInfo> sparePartInfos, Guid maintenanceId, float price)
        {
            if (sparePartInfos.Any())
            {
                foreach (var i in sparePartInfos)
                {
                    var sp = _mapper.Map<MaintenanceSparePartInfo>(i);
                    if (sp.SparePartsItemCostId == null)
                    {
                        throw new Exception("Require add Product in Center Cost");
                    }
                    sp.Status = EnumStatus.ACTIVE.ToString();
                    sp.CreatedDate = DateTime.Now;
                    sp.Discount = 10;
                    sp.TotalCost = (sp.ActualCost * sp.Quantity) * (1 - (sp.Discount / 100));
                    sp.InformationMaintenanceId = maintenanceId;
                    await _unitOfWork.SparePartsItemCost.GetById(sp.SparePartsItemCostId);
                    //await _unitOfWork.SparePartsItem.GetByStatusAndCostActive(sp.SparePartsItemId);
                    price = sp.TotalCost + i.TotalCost;

                    await _unitOfWork.MaintenanceSparePartInfo.Add(sp);
                }
            }
            return price;
        }

        private async Task<float> ProcessServiceInfos(IEnumerable<MaintenanceServiceInfo> serviceInfos, Guid maintenanceId, float price)
        {
            if (serviceInfos.Any())
            {
                foreach (var i in serviceInfos)
                {
                    var msi = _mapper.Map<MaintenanceServiceInfo>(i);
                    if (msi.MaintenanceServiceCostId == null)
                    {
                        throw new Exception("Require add Product in Center");
                    }
                    msi.Status = EnumStatus.ACTIVE.ToString();
                    msi.CreatedDate = DateTime.Now;
                    msi.Discount = 10;
                    msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount / 100));
                    msi.InformationMaintenanceId = maintenanceId;
                    await _unitOfWork.MaintenanceServiceCost.GetById(msi.MaintenanceServiceCostId);
                    await _unitOfWork.MaintenanceServiceInfo.Add(msi);
                }
            }
            return price;
        }
        private MaintenanceInformation MapAndInitializeMaintenanceInformation(CreateMaintenanceInformationHaveItems create)
        {
            var mi = _mapper.Map<MaintenanceInformation>(create);
            mi.CreatedDate = DateTime.Now;
            mi.TotalPrice = 0;
            mi.Status = EnumStatus.CREATEDBYClIENT.ToString();
            return mi;
        }

        private async Task<ResponseMaintenanceInformation> HandleNullBookingId(MaintenanceInformation mi)
        {
            await _unitOfWork.InformationMaintenance.Add(mi);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(mi);
        }

        private async Task<ResponseMaintenanceInformation> HandleNonNullBookingId(MaintenanceInformation mi)
        {
            var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
            booking.Status = "ACCEPT";

            await _unitOfWork.InformationMaintenance.Add(mi);
            MaintenanceHistoryStatus historyStatus = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = Guid.NewGuid(),
                Status = EnumStatus.CREATEDBYCUSTOMERCARE.ToString(),
                DateTime = DateTime.Now,
                MaintenanceInformationId = mi.InformationMaintenanceId,
                Note = mi.Note,
            };
            await _unitOfWork.MaintenanceHistoryStatuses.Add(historyStatus);

            await _unitOfWork.Booking.Update(booking);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(mi);
        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByClient()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByClient(account.Client.ClientId));

        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        }

        public async Task Remove(Guid id)
        {
            var re = await _unitOfWork.InformationMaintenance.GetById(id);
            await _unitOfWork.InformationMaintenance.Remove(re);
        }

        public async Task<ResponseMaintenanceInformation> ChangeStatus(Guid id, string status)
        {
            var re = await _unitOfWork.InformationMaintenance.GetById(id);
            //re.Status = status;
            if (re.Status.Equals(STATUSENUM.STATUSMI.WAITINGBYCAR.ToString()) && status.Equals(STATUSENUM.STATUSMI.CHECKIN.ToString()))
            {

                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = EnumStatus.CHECKIN.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = EnumStatus.CHECKIN.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = re.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                }
                re.Status = status;
            }
            await _unitOfWork.InformationMaintenance.Update(re);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseMaintenanceInformation>(re);
        }

        public async Task<ResponseMaintenanceInformation> ChangeStatusBackUp(Guid id, string status)
        {
            var re = await _unitOfWork.InformationMaintenance.GetById(id);
            re.Status = status;
            await _unitOfWork.InformationMaintenance.Update(re);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(re);

        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenterAnd(string status)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByCenterAndStatus(account.MaintenanceCenter.MaintenanceCenterId, status));
        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenterAndStatusCheckinAndTaskInactive()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByCenterAndStatusCheckinAndTaskInactive(account.MaintenanceCenter.MaintenanceCenterId));

        }

        //public Task<List<ResponseMaintenanceInformation>> GetListByCenterAndStatusCheckin(Guid id)
        //{
        //    return _mapper.Map<List<ResponseMaintenanceInformation>>(
        //                   await _unitOfWork.InformationMaintenance.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        //}
    }
}
