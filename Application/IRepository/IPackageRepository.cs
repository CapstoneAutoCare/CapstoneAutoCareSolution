using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IPackageRepository : IGenericRepository<Package>
    {
        Task<List<Package>> GetAll();
        Task<Package> GetById(Guid id);
    }
}
