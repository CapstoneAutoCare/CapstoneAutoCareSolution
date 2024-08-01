using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataMaintenanceService
    {
        public static List<MaintenanceService> GetMaintenanceServices(List<MaintenanceCenter> centers, List<ServiceCares> serviceCares)
        {
            return centers.AsParallel().SelectMany(center =>
                serviceCares.Select(serviceCare => new MaintenanceService
                {
                    MaintenanceServiceId = Guid.NewGuid(),
                    Status = EnumStatus.ACTIVE.ToString(),
                    MaintenanceServiceName = serviceCare.ServiceCareName,
                    CreatedDate = DateTime.Now,
                    Image = "",
                    ServiceCareId = serviceCare.ServiceCareId,
                    MaintenanceCenterId = center.MaintenanceCenterId,
                })
            ).ToList();
        }
    }
}
