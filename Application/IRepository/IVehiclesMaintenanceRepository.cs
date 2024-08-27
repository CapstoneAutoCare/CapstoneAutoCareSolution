using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IVehiclesMaintenanceRepository: IGenericRepository<VehiclesMaintenance>
    {
        Task<List<VehiclesMaintenance>> GetAll();
        Task<List<VehiclesMaintenance>> GetListByCenter(Guid id);
    }
}
