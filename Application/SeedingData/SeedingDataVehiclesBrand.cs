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
            var brandNames = new List<string>
        {
            EnumBrand.BMW.ToString(),
            EnumBrand.MEC.ToString(),
            EnumBrand.AUDI.ToString(),
            EnumBrand.TOYOTA.ToString(),
            EnumBrand.HONDA.ToString()
        };
            return brandNames.Select(brandName => new VehiclesBrand
            {
                CreatedDate = DateTime.Now,
                Status = EnumStatus.ACTIVE.ToString(),
                VehiclesBrandName = brandName,
                VehiclesBrandId = Guid.NewGuid()
            }).ToList();
        }
    }
}
