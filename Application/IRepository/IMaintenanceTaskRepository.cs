using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceTaskRepository : IGenericRepository<MaintenanceTask>
    {
        Task<MaintenanceTask> GetById(Guid id);
        Task<List<MaintenanceTask>> GetAll();
        Task<List<MaintenanceTask>> GetListByCenter(Guid id);
        Task<List<MaintenanceTask>> GetListByCustomerCare(Guid id);
        Task<List<MaintenanceTask>> GetListByTech(Guid id);
        Task<List<MaintenanceTask>> GetListByInfor(Guid id);

        Task<MaintenanceTask> CheckExistByTechAndInfor(Guid techId,Guid inforId);
        Task<MaintenanceTask> CheckTaskByInforId(Guid id,string status);
    }
}
