using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IPackageCenterRepository : IGenericRepository<CenterPackages>
    {
        Task<List<CenterPackages>> GetAll();
        Task<List<CenterPackages>> GetListByCenterId(Guid id);
        Task<CenterPackages> GetById(Guid id);
        Task<List<CenterPackages>> GetListByPackageId(Guid id);

    }
}
