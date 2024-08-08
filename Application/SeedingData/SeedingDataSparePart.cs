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
                "Piston",
                "Trục Cam",
                "xupap",
                "Bu Lông",
                "Má Phanh" ,
                "Hộp số" ,
                //"Ống Dẫn Dầu Phanh" ,
                //"Bộ Trợ Lực Phanh" ,
                //"Vô Lăng" ,
                //"Cột Lái" ,
                //"Hệ Thống Trợ Lực Lái" ,
                //"Cơ Cấu Lái" ,
                //"Lò Xo" ,
                //"Thanh Cân Bằng" ,
                //"Ống Xả" ,
                //"Bộ Giảm Thanh" ,
                //"Bộ Lọc Khí Thải" ,
                //"Ắc Quy" ,
                //"Máy Phát Điện" ,
                //"Bộ Điều Khiển" ,
                //"Hệ Thống Dây Điện" ,
                //"Bình Xăng" ,
                //"Bơm Nhiên Liệu" ,
                //"Bộ Phun Nhiên Liệu" ,
                //"Bộ Lọc Nhiên Liệu" ,
                //"Két Nước",
                //"Bơm Nước",
                //"Quạt Làm Mát",
                //"Máy Nén",
                //"Giàn Nóng",
                //"Giàn Lạnh",
                //"Đèn Pha",
                //"Đèn Hậu",
                //"Đèn Xi Nhan",
                //"Lốp Xe",
                //"Vành (la-zăng)",
                //"Cần Gạt Nước",
                //"Bu-gi (bugi)",
                //"Ống xả",
                //"Bóng đèn",
                //"Dầu trợ lực lái",
                //"Giảm Chấn",
                //"Dây curoa",
                //"Rotuyn lái",
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
                     Status = EnumStatus.ACTIVE.ToString(),
                 }).ToList());
            }
            return spareParts;
        }
    }
}
