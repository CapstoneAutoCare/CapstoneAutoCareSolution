using Domain.Entities;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.VehiclesResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IVehicleModelService
    {
        Task<ReponseVehicleModels> GetVehicleById(Guid id);
        Task<ReponseVehicleModels> CreateNewVehicleModel(CreateVehicleModel vehicleModel);
        Task<ReponseVehicleModels> UpdateVehicleModel(Guid id, UpdateVehicleModel vehicleModel);
        Task<ReponseVehicleModels> UpdateStatusVehicleModel(Guid id,string status);
        Task<List<ReponseVehicleModels>> GetAllVehiclesModels();
        Task<List<ReponseVehicleModels>> GetListVehicleByBrandId(Guid id);

    }
}
