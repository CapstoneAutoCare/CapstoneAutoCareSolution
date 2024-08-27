using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IVehicleModelRepository: IGenericRepository<VehicleModel>
    {
        Task<List<VehicleModel>> GetAll();
        Task<VehicleModel> GetById(Guid id);
        Task<List<VehicleModel>>GetListByBrandId(Guid brandId);
        Task<VehicleModel> CheckExist(string name,Guid brandId);
        Task<List<VehicleModel>> GetListActiveByBrandId(Guid brandId);
    }
}
