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
            // 9 schedule
            return new List<MaintananceSchedule>
            {
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="1000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="5000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="100000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="15000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="20000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="25000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="30000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="35000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                },
                new MaintananceSchedule {
                    MaintananceScheduleId = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    MaintananceScheduleName="40000",
                    Description="Km",
                    VehicleModelId=vehicle.VehicleModelId,
                }
            };
        }

    }
}
