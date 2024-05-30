using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintenanceInformation;
using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Response.ResponseMaintenanceInformation;
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
                booking.Status = "ACCEPT";
                await _unitOfWork.InformationMaintenance.Add(mi);
                await _unitOfWork.Booking.Update(booking);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(mi);
            }
        }

        public async Task<ResponseMaintenanceInformation> CreateHaveItems(CreateMaintenanceInformationHaveItems create)
        {
            var mi = _mapper.Map<MaintenanceInformation>(create);
            var email = _tokensHandler.ClaimsFromToken();
            mi.CreatedDate = DateTime.Now;
            mi.TotalPrice = 0;
            var account = await _unitOfWork.Account.Profile(email);
            var customercare = await _unitOfWork.CustomerCare.GetById(account.CustomerCare.CustomerCareId);
            mi.CustomerCareId = customercare.CustomerCareId;
            if (mi.MaintenanceSparePartInfos.Count() > 0)
            {
                foreach (var i in mi.MaintenanceSparePartInfos)
                {
                    var sp = _mapper.Map<MaintenanceSparePartInfo>(i);
                    if (sp.SparePartsItemId == null)
                    {
                        throw new Exception("Require add Product in Center");
                    }
                    sp.Status = "INACTIVE";
                    sp.CreatedDate = DateTime.Now;
                    sp.Discount = 10;
                    sp.TotalCost = (sp.ActualCost * sp.Quantity) * (1 - (sp.Discount) / 100);
                    sp.InformationMaintenanceId = mi.InformationMaintenanceId;
                    await _unitOfWork.SparePartsItem.GetById(sp.SparePartsItemId);
                    await _unitOfWork.MaintenanceSparePartInfo.Add(sp);
                }
            }
            if (mi.MaintenanceServiceInfos.Count() > 0)
            {
                foreach (var i in mi.MaintenanceServiceInfos)
                {
                    var msi = _mapper.Map<MaintenanceServiceInfo>(i);
                    if (msi.MaintenanceServiceId == null)
                    {
                        throw new Exception("Require add Product in Center");
                    }
                    msi.Status = "INACTIVE";
                    msi.CreatedDate = DateTime.Now;
                    msi.Discount = 10;
                    msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount) / 100);
                    msi.InformationMaintenanceId = mi.InformationMaintenanceId;
                    await _unitOfWork.MaintenanceService.GetById(msi.MaintenanceServiceId);
                    await _unitOfWork.MaintenanceServiceInfo.Add(msi);
                }
            }

            if (mi.BookingId == null)
            {
                await _unitOfWork.InformationMaintenance.Add(mi);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(mi);
            }
            var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
            booking.Status = "ACCEPT";

            await _unitOfWork.InformationMaintenance.Add(mi);
            MaintenanceHistoryStatus historyStatus = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = new Guid(),
                Status = "CREATE BY CUSTOMER CARE",
                DateTime = DateTime.Now,
                MaintenanceInformationId = mi.InformationMaintenanceId,  
                Note = mi.Note,
            };
            await _unitOfWork.MaintenanceHistoryStatuses.Add(historyStatus);

            await _unitOfWork.Booking.Update(booking);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(mi);
        }

        public async Task<List<ResponseMaintenanceInformation>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceInformation>>(await _unitOfWork.InformationMaintenance.GetAll());
        }

        public async Task<ResponseMaintenanceInformation> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceInformation>(await _unitOfWork.InformationMaintenance.GetById(id));
        }

    }
}
