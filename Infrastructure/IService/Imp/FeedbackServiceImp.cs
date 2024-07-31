using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestFb;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseFb;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class FeedbackServiceImp : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        public FeedbackServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }
        public async Task<ResponseFeedback> Create(CreateFeedBack create)
        {
            var feedback = _mapper.Map<FeedBack>(create);
            //var reciept = _unitOfWork.ReceiptRepository.GetById(create.ReceiptId);

            var mc = await _unitOfWork.MaintenanceCenter.GetById(create.MaintenanceCenterId);
            var rc = await _unitOfWork.ReceiptRepository.GetById(create.ReceiptId);

            feedback.MaintenanceCenter = mc;
            feedback.Receipt = rc;

            if (rc.Status != "PAID") throw new Exception("You need complete payment to give feedback");

            await _unitOfWork.FeedBack.Add(feedback);
            await _unitOfWork.Commit();


            return _mapper.Map<ResponseFeedback>(feedback);
        }

        public async Task<List<ResponseFeedback>> GetAll()
        {
            var fb = await _unitOfWork.FeedBack.GetAll();
            return _mapper.Map<List<ResponseFeedback>>(fb);
        }

        public async Task<ResponseFeedback> GetById(Guid id)
        {
            var fb = await _unitOfWork.FeedBack.GetById(id);
            await _unitOfWork.MaintenanceCenter.GetById(fb.MaintenanceCenterId);
            await _unitOfWork.ReceiptRepository.GetById(fb.ReceiptId);
            return _mapper.Map<ResponseFeedback>(fb);
        }

        public async Task<List<ResponseFeedback>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var list = await _unitOfWork.FeedBack.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId);
            return _mapper.Map<List<ResponseFeedback>>(list);
        }

        public async Task Remove(Guid id)
        {
            var u = await _unitOfWork.FeedBack.GetById(id);
            await _unitOfWork.FeedBack.Remove(u);
            await _unitOfWork.Commit();
        }

        public async Task<ResponseFeedback> Update(Guid id, UpdateFeedback update)
        {
            var item = await _unitOfWork.FeedBack.GetById(id);

            item.Vote = update.vote;
            item.Comment = update.comment;

            await _unitOfWork.FeedBack.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseFeedback>(item);
        }
    }
}
