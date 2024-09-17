using AutoMapper;
using Infrastructure.Common.Response;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class TransactionServiceImp : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokenHandler;

        public TransactionServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokenHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<List<ResponseTransaction>> GetAll()
        {
            return _mapper.Map<List<ResponseTransaction>>(await _unitOfWork.TransactionRepository.GetAll());
        }

        public async Task<ResponseTransaction> GetById(Guid id)
        {
            return _mapper.Map<ResponseTransaction>(await _unitOfWork.TransactionRepository.GetById(id));
        }


        public async Task<List<ResponseTransaction>> GetListByCenterAndStatusTransferred(Guid id)
        {
            return _mapper.Map<List<ResponseTransaction>>(await _unitOfWork.TransactionRepository.GetListByCenterIdAndStatusTransferred(id));
        }

        public async Task<List<ResponseTransaction>> GetListByClientRECEIVED(Guid id)
        {
            return _mapper.Map<List<ResponseTransaction>>(await _unitOfWork.TransactionRepository.GetListByClientRECEIVED(id));
        }
    }
}
