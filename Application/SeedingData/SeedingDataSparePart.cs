using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataSparePart
    {

        public static  List<SpareParts> GetSpareParts(List<VehicleModel> vehicleModels)
        {
            var sparePartsName = new[] {
                "Lọc Dầu",
                "Lọc Gió Điều Hòa",
                "Lọc Gió Động Cơ",
                "Bu Lông",
                "Má Phanh" ,
                "Hộp số" ,
                "Xịt Rỉ Bôi Trơn" ,

            };
            var spareParts = new List<SpareParts>();
            foreach (var vehicleModel in vehicleModels)
            {
                spareParts.AddRange(
                 sparePartsName.Select(name => new SpareParts
                 {
                     CreatedDate = DateTime.Now,
                     SparePartId = Guid.NewGuid(),
                     OriginalPrice = 100000,
                     SparePartName = name,
                     SparePartType = name,
                     SparePartDescription = name,
                     VehicleModelId = vehicleModel.VehicleModelId,
                     Image=null,
                    
                     Status = EnumStatus.ACTIVE.ToString(),
                 }).ToList());
            }
            return spareParts;
        }
    }
}
