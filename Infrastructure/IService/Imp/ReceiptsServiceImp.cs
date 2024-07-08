using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.ReceiptRequest;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.Common.Response.ReceiptResponse;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
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

        public ReceiptsServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseReceipts> Create(CreateReceipt receipt)
        {
            var r = _mapper.Map<Receipt>(receipt);
            var i = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
            r.CreatedDate = DateTime.Now;
            r.ReceiptName = "Receipt";
            //r.TotalAmount = 0;
            //r.SubTotal = 0;
            r.VAT = 30;
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

        public async Task<List<ResponseReceipts>> GetListByCenter()
        {
            var mail = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(mail);

            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        }
    }
}
