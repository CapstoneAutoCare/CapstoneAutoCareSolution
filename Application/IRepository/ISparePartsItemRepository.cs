using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ISparePartsItemRepository: IGenericRepository<SparePartsItem>
    {
        Task<List<SparePartsItem>> GetAll();
        Task<SparePartsItem> GetByID(Guid id);
    }
}
