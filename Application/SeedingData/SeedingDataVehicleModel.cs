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

        private static List<VehicleModel> GetBMW(VehiclesBrand brand)
        {
            return new List<VehicleModel>
            {
                // 6 xe
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="320i",
                    Image="320i",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="328i",
                    Image="328i",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="330i",
                    Image="330i",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="i7",
                    Image="i7",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="740Li",
                    Image="740Li",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="M6",
                    Image="M6",
                    VehiclesBrandId=brand.VehiclesBrandId,
                },
            };
        }
        private static List<VehicleModel> GetMEC(VehiclesBrand brand)
        {
            return new List<VehicleModel>
            {
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="E180",
                    Image="E180",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="S450",
                    Image="S450",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="C300",
                    Image="C300",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="C250",
                    Image="C250",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="C200",
                    Image="C200",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="GLC 300",
                    Image="GLC 300",
                    VehiclesBrandId=brand.VehiclesBrandId,
                },
            };
        }
        private static List<VehicleModel> GetAUDI(VehiclesBrand brand)
        {
            return new List<VehicleModel>
            {
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="A1",
                    Image="A1",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="A3",
                    Image="A3",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Q7",
                    Image="Q7",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="A5",
                    Image="A5",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="A6",
                    Image="A6",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="A4",
                    Image="A4",
                    VehiclesBrandId=brand.VehiclesBrandId,
                }
            };
        }
        private static List<VehicleModel> GetTOYOTA(VehiclesBrand brand)
        {
            return new List<VehicleModel>
            {
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Vios",
                    Image="Vios",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Yaris",
                    Image="Yaris",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Camry",
                    Image="Camry",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Fortuner",
                    Image="Fortuner",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Alphard",
                    Image="Alphard",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Harrier",
                    Image="Harrier",
                    VehiclesBrandId=brand.VehiclesBrandId,
                }
            };
        }
        private static List<VehicleModel> GetHONDA(VehiclesBrand brand)
        {
            return new List<VehicleModel>
            {
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Civic",
                    Image="Civic",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="City",
                    Image="City",
                    VehiclesBrandId=brand.VehiclesBrandId,
                    //VehiclesBrand=brand
                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Brio",
                    Image="Brio",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Jazz",
                    Image="Jazz",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="BR-V",
                    Image="BR-V",
                    VehiclesBrandId=brand.VehiclesBrandId,

                },
                new VehicleModel {
                    VehicleModelId = Guid.NewGuid(),
                    Status=EnumStatus.ACTIVE.ToString(),
                    CreatedDate=DateTime.Now,
                    VehicleModelName="Ridgeline",
                    Image="Ridgeline",
                    VehiclesBrandId=brand.VehiclesBrandId,
                }
            };
        }

        public static List<VehicleModel> ServiceSeedingDataVehicleModel(ModelBuilder modelBuilder, List<VehiclesBrand> vehicleBrands)
        {
            var vehicleModels = new List<VehicleModel>();
            foreach (var brand in vehicleBrands)
            {
                switch (brand.VehiclesBrandName)
                {
                    case "BMW":
                        vehicleModels = GetBMW(brand);
                        break;
                    case "MEC":
                        vehicleModels = GetMEC(brand);
                        break;
                    case "AUDI":
                        vehicleModels = GetAUDI(brand);
                        break;
                    case "TOYOTA":
                        vehicleModels = GetTOYOTA(brand);
                        break;
                    case "HONDA":
                        vehicleModels = GetHONDA(brand);
                        break;
                }
                modelBuilder.Entity<VehicleModel>().HasData(vehicleModels);
            }
            return vehicleModels;
        }

    }
}
