using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IVehiclesBrandRepository: IGenericRepository<VehiclesBrand>
    {
        Task<VehiclesBrand> GetById(Guid id);
        Task<VehiclesBrand> GetBrandbyName(string brandName);
        Task<List<VehiclesBrand>> GetAll();
        Task<List<VehiclesBrand>> GetListBrandActive();
        Task<List<VehiclesBrand>> GetBrandsNotInCenter(Guid centerId);

    }
}
