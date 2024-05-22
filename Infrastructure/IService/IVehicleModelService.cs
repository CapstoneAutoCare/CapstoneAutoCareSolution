using Domain.Entities;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response.ReponseVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IVehicleModelService
    {
        Task<ReponseVehicleModel> GetVehicleById(Guid id);
        Task<ReponseVehicleModel> CreateNewVehicleModel(CreateVehicleModel vehicleModel);
        Task<ReponseVehicleModel> UpdateVehicleModel(Guid id, UpdateVehicleModel vehicleModel);
        Task<ReponseVehicleModel> UpdateStatusVehicleModel(Guid id,string status);]
        Task<List<ReponseVehicleModel>> GetAllVehicles();

    }
}
