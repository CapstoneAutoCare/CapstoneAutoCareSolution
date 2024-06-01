using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataVehiclesBrand
    {
        public static List<VehiclesBrand> Get()
        {
            return new List<VehiclesBrand>
        {
                new VehiclesBrand
                {
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    VehiclesBrandName=EnumBrand.BMW.ToString(),
                    VehiclesBrandId =Guid.NewGuid(),
                },
                new VehiclesBrand
                {
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    VehiclesBrandName=EnumBrand.MEC.ToString(),
                    VehiclesBrandId =Guid.NewGuid(),
                },
                new VehiclesBrand {
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    VehiclesBrandName=EnumBrand.AUDI.ToString(),
                    VehiclesBrandId =Guid.NewGuid()
                },
                new VehiclesBrand {
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    VehiclesBrandName=EnumBrand.TOYOTA.ToString(),
                    VehiclesBrandId =Guid.NewGuid()
                },
                new VehiclesBrand {
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    VehiclesBrandName=EnumBrand.HONDA.ToString(),
                    VehiclesBrandId =Guid.NewGuid()
                },

        };
        }
    }
}
