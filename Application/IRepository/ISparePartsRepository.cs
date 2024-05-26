using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ISparePartsRepository: IGenericRepository<SpareParts>
    {
        Task<List<SpareParts>> GetAll();
        Task<SpareParts> GetByID(Guid? id);
    }
}
