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


            return vehicles.SelectMany(ve => scheduleDistances.Select(distance => new MaintananceSchedule
            {
                CreateDate = DateTime.Now,
                VehicleModelId = ve.VehicleModelId,
                MaintananceScheduleName = distance,
                MaintananceScheduleId=Guid.NewGuid(),
                Status=EnumStatus.ACTIVE.ToString(),
                Description=distance.ToString(),
                
            })).ToList();
        }

    }
}
