using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataMaintenanceServiceCost
    {
        static float GetRandomNumber()
        {
            Random random = new Random();

            int randomBase = random.Next(50, 1001); 

            float randomNumber = randomBase * 1000;

            return randomNumber;
        }

        public static List<MaintenanceServiceCost> GetMaintenanceServiceCost(List<MaintenanceService> maintenanceServices)
        {
            return maintenanceServices.Select(c => new MaintenanceServiceCost
            {
                ActuralCost = GetRandomNumber(),
                DateTime = DateTime.Now,
                MaintenanceServiceId = c.MaintenanceServiceId,
                Note = "",
                MaintenanceServiceCostId = Guid.NewGuid(),
                Status = EnumStatus.ACTIVE.ToString()
            }).ToList();
        }
    }
}
