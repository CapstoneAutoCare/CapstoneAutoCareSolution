using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IReceiptRepository : IGenericRepository<Receipt>
    {
        Task<List<Receipt>> GetAll();
        Task<Receipt> GetById(Guid id);
        Task<List<Receipt>> GetListByCenter(Guid id);
    }
}
