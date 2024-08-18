using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.ReceiptRequest;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.Common.Response.ReceiptResponse;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class ReceiptsServiceImp : IReceiptsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IConfiguration _configuration;
        public ReceiptsServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _configuration = configuration;
        }

        public async Task<ResponseReceipts> ChangeStatus(Guid id, string status)
        {
            var r = await _unitOfWork.ReceiptRepository.GetById(id);
            if (r.Status.Equals(EnumStatus.YETPAID.ToString())
                && status.Equals(EnumStatus.PAID.ToString()))
            {
                r.Status = status;
                var i = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
                i.Status = status;
                await _unitOfWork.InformationMaintenance.Update(i);
                await _unitOfWork.ReceiptRepository.Update(r);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseReceipts>(r);
            }
            else
            {
                throw new Exception("Can't Change Status " + status + " Status has  PAID");

            }

        }

        public async Task<ResponseReceipts> Create(CreateReceipt receipt)
        {
            var r = _mapper.Map<Receipt>(receipt);
            var i = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
            await _unitOfWork.MaintenanceTask
                .CheckTaskByInforId(i.InformationMaintenanceId, EnumStatus.DONE.ToString());
            r.CreatedDate = DateTime.Now;
            r.ReceiptName = "Receipt";
            //r.TotalAmount = 0;
            //r.SubTotal = 0;
            r.VAT = _configuration.GetValue<int>("VAT");
            r.SubTotal = i.TotalPrice;
            r.TotalAmount = (float)Math.Round(r.SubTotal * (1 + (r.VAT / 100f)), 0, MidpointRounding.AwayFromZero);
            r.Status = EnumStatus.YETPAID.ToString();
            i.Status = EnumStatus.YETPAID.ToString();
            await _unitOfWork.InformationMaintenance.Update(i);
            await _unitOfWork.ReceiptRepository.Add(r);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseReceipts>(r);
        }

        public async Task<List<ResponseReceipts>> GetAll()
        {
            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetAll());
        }

        public async Task<ResponseReceipts> GetById(Guid id)
        {
            return _mapper.Map<ResponseReceipts>(await _unitOfWork.ReceiptRepository.GetById(id));
        }

        public async Task<ResponseReceipts> GetByInforId(Guid id)
        {
            return _mapper.Map<ResponseReceipts>(await _unitOfWork.ReceiptRepository.GetByInfor(id));
        }

        public async Task<List<ResponseReceipts>> GetListByCenter()
        {
            var mail = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(mail);

            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        }

        public async Task<List<ResponseReceipts>> GetListByCenter(Guid id)
        {
            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByCenter(id));
        }

        public async Task<List<ResponseReceipts>> GetListByClient()
        {
            var mail = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(mail);

            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByClient(account.Client.ClientId));

        }

        public async Task Remove(Guid id)
        {
            var r = await _unitOfWork.ReceiptRepository.GetById(id);
            var i = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
            //i.Status = EnumStatus.PAYMENT.ToString();
            if (r.Status != EnumStatus.YETPAID.ToString())
            {
                throw new Exception("PAID not Remove");
            }
            //await _unitOfWork.InformationMaintenance.Update(i);
            await _unitOfWork.ReceiptRepository.Remove(r);
            await _unitOfWork.Commit();
        }
    }
}
