using Application.IGenericRepository;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceCenterRepository: IGenericRepository<MaintenanceCenter>
    {
        Task<MaintenanceCenter> GetById(Guid id);
        Task<List<MaintenanceCenter>> GetAll();
        Task<List<MaintenanceCenter>> GetAllActive();
    }
}
