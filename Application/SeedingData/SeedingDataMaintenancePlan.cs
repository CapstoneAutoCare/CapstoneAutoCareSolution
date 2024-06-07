using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public class SeedingDataMaintenancePlan
    {
        public static List<MaintenancePlan> Get(MaintananceSchedule schedule)
        {
            return new List<MaintenancePlan>
            {
                new MaintenancePlan
                {
                    CreateDate = DateTime.Now,
                    MaintenancePlanId=Guid.NewGuid(),
                    MaintenancePlanName=1000,
                    MaintenancePlanDescription="Km",
                    Status=EnumStatus.ACTIVE.ToString(),
                    MaintananceScheduleId=schedule.MaintananceScheduleId,
                },
                new MaintenancePlan
                {
                    CreateDate = DateTime.Now,
                    MaintenancePlanId=Guid.NewGuid(),
                    MaintenancePlanName=5000,
                    MaintenancePlanDescription="Km",
                    Status=EnumStatus.ACTIVE.ToString(),
                    MaintananceScheduleId=schedule.MaintananceScheduleId,

                },
                new MaintenancePlan
                {
                    CreateDate = DateTime.Now,
                    MaintenancePlanId=Guid.NewGuid(),
                    MaintenancePlanName=10000,
                    MaintenancePlanDescription="Km",
                    Status=EnumStatus.ACTIVE.ToString(),
                    MaintananceScheduleId=schedule.MaintananceScheduleId,
                },
                new MaintenancePlan
                {
                    CreateDate = DateTime.Now,
                    MaintenancePlanId=Guid.NewGuid(),
                    MaintenancePlanName=20000,
                    MaintenancePlanDescription="Km",
                    Status=EnumStatus.ACTIVE.ToString(),
                    MaintananceScheduleId=schedule.MaintananceScheduleId,
                },
                new MaintenancePlan
                {
                    CreateDate = DateTime.Now,
                    MaintenancePlanId=Guid.NewGuid(),
                    MaintenancePlanName=40000,
                    MaintenancePlanDescription="Km",
                    Status=EnumStatus.ACTIVE.ToString(),
                    MaintananceScheduleId=schedule.MaintananceScheduleId,
                },
                new MaintenancePlan
                {
                    CreateDate = DateTime.Now,
                    MaintenancePlanId=Guid.NewGuid(),
                    MaintenancePlanName=80000,
                    MaintenancePlanDescription="Km",
                    Status=EnumStatus.ACTIVE.ToString(),
                    MaintananceScheduleId=schedule.MaintananceScheduleId,
                },
            };
        }
    }
}
