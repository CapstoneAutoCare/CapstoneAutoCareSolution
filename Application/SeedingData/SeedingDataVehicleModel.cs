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
    public partial class SeedingDataVehicleModel
    {
        private static VehicleModel CreateVehicleModel(Guid brandId, string modelName)
        {
            return new VehicleModel
            {
                VehicleModelId = Guid.NewGuid(),
                Status = EnumStatus.ACTIVE.ToString(),
                CreatedDate = DateTime.Now,
                VehicleModelName = modelName,
                Image = "",
                VehiclesBrandId = brandId,
                VehicleModelDecription = modelName,

            };
        }
        private static readonly Dictionary<string, List<string>> BrandModels = new Dictionary<string, List<string>>
        {
            //{ EnumBrand.BMW.ToString(), new List<string> { "330i","740Li" } },
            //{ EnumBrand.MEC.ToString(), new List<string> { "E300 AMG", "S450","GLC 300" } },
            //{ EnumBrand.AUDI.ToString(), new List<string> { "A1", "A3", "Q7", "A5", "A6", "A4" } },
            { EnumBrand.TOYOTA.ToString(), new List<string> { "Vios", "Camry",} },
            { EnumBrand.HONDA.ToString(), new List<string> { "Civic", "City"  } }
        };
        public static List<VehicleModel> ServiceSeedingDataVehicleModel(List<VehiclesBrand> vehicleBrands)
        {
            var vehicleModels = new List<VehicleModel>();

            foreach (var brand in vehicleBrands)
            {

                if (BrandModels.TryGetValue(brand.VehiclesBrandName, out var models))
                {
                    var list = models.Select(modelName => CreateVehicleModel(brand.VehiclesBrandId, modelName)).ToList();
                    vehicleModels.AddRange(list);
                }
            }

            return vehicleModels;
        }

    }
}
