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

        public Task<List<ResponseTransaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseTransaction> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
