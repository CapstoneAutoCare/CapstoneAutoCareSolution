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
        Task<ResponseVehicleModel> GetVehicleById(Guid id);
        Task<ResponseVehicleModel> CreateNewVehicleModel(CreateVehicleModel vehicleModel);
        Task<ResponseVehicleModel> UpdateVehicleModel(Guid id, UpdateVehicleModel vehicleModel);
        Task<ResponseVehicleModel> UpdateStatusVehicleModel(Guid id,string status);
        Task<List<ResponseVehicleModel>> GetAllVehiclesModels();

    }
}
