using Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ITransactionService
    {
        Task<List<ResponseTransaction>> GetAll();
        Task<ResponseTransaction> GetById(Guid id);

    }
}
