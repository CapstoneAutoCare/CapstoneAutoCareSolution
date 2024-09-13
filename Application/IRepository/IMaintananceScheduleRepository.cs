using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintananceScheduleRepository: IGenericRepository<MaintananceSchedule>
    {
        Task<List<MaintananceSchedule>> GetAll();
        Task<MaintananceSchedule> GetByID(Guid? id);
        Task<List<MaintananceSchedule>> GetListPackageByCenterId(Guid id);
        Task<List<MaintananceSchedule>> GetListPlanIdAndPackageCenterId(Guid planid, Guid id);
        Task<List<MaintananceSchedule>> GetListPlanIdAndPackageCenterIdBookingId(Guid planid, Guid id,Guid bookingId);

        Task<List<MaintananceSchedule>> GetListPackageByPlanId(Guid id);
    }
}
