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
        public static List<MaintananceSchedule> Get(List<VehicleModel> vehicles)
        {
            var scheduleDistances = new[] { 5000, 10000, 50000 };

            var maintenanceSchedules = new List<MaintananceSchedule>();
            foreach (var vehicle in vehicles)
            {
                maintenanceSchedules.AddRange(
                 scheduleDistances.Select(distance => new MaintananceSchedule
                 {
                     MaintananceScheduleId = Guid.NewGuid(),
                     CreateDate = DateTime.Now,
                     MaintananceScheduleName = distance,
                     Description = "Km",
                     VehicleModelId = vehicle.VehicleModelId,
                 }).ToList());
            }
            return maintenanceSchedules;

        }

    }
}
