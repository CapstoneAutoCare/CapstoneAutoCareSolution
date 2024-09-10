using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataMaintanancePlan
    {
        public static List<MaintenancePlan> Get(List<VehicleModel> vehicleModels)
        {
            var planName = new[] {
                "Bảo dưỡng cấp nhỏ",
                "Bảo dưỡng cấp trung bình",
                "Bảo dưỡng cấp trung bình lớn",
                "Bảo dưỡng cấp lớn",
            };
            return vehicleModels.SelectMany(model => planName.Select(plan=>new MaintenancePlan
            {
                MaintenancePlanId=Guid.NewGuid(),
                DateTime = DateTime.Now,
                Description= plan,
                MaintenancePlanName=plan,
                Status=EnumStatus.ACTIVE.ToString(),
                VehicleModelId=model.VehicleModelId,
            })).ToList();

            
        }
    }
}
