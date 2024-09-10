using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataMaintananceSchedule
    {
        public static List<MaintananceSchedule> Get(List<MaintenancePlan> plans)
        {
            var scheduleDistances = new[] { 5000, 10000, 25000,35000 };


            return plans.SelectMany(plan => scheduleDistances.Select(distance => new MaintananceSchedule
            {
                CreateDate = DateTime.Now,
                MaintenancePlanId = plan.MaintenancePlanId,
                MaintananceScheduleName = distance,
                MaintananceScheduleId=Guid.NewGuid(),
                Status=EnumStatus.ACTIVE.ToString(),
                Description=distance.ToString(),
                
            })).ToList();
        }

    }
}
