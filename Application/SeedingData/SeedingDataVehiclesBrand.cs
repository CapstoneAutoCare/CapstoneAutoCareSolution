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
            //EnumBrand.BMW.ToString(),
            //EnumBrand.MEC.ToString(),
            //EnumBrand.AUDI.ToString(),
            EnumBrand.TOYOTA.ToString(),
            EnumBrand.HONDA.ToString()
        };
            var brandLogos = new List<string>
    {
        //"https://vudigital.co/wp-content/uploads/2021/10/logo-bmw-lich-su-hinh-thanh-va-phat-trien-tu-1916-voi-su-nham-lan-thu-vi-9.jpg",
        //"https://mercedeshanoi.com.vn/wp-content/uploads/logo-mercedes-benz.jpg",
        //"https://inkythuatso.com/uploads/thumbnails/800/2021/11/logo-audi-inkythuatso-01-11-13-45-50.jpg",
        "https://inkythuatso.com/uploads/thumbnails/800/2021/11/logo-toyota-inkythuatso-3-01-11-15-32-59.jpg",
        "https://vudigital.co/wp-content/uploads/2021/09/logo-honda-bieu-tuong-duoc-bao-ton-lau-nhat-the-gioi-tu-1961-8.jpg"
    };

            return brandNames.Select((brandName, index) => new VehiclesBrand
            {
                CreatedDate = DateTime.Now,
                Status = EnumStatus.ACTIVE.ToString(),
                VehiclesBrandName = brandName,
                VehiclesBrandId = Guid.NewGuid(),
                Logo = brandLogos[index],
                VehiclesBrandDescription = brandName,
            }).ToList();
        }
    }
}
