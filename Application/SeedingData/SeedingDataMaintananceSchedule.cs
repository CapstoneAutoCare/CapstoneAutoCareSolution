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
        public static List<MaintananceSchedule> Get(VehicleModel vehicle)
        {
            return new List<MaintananceSchedule>
            {
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=1000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=5000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=100000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=15000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=20000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=25000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=30000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=35000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Odo=40000,
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                }
            };
        }

    }
}
