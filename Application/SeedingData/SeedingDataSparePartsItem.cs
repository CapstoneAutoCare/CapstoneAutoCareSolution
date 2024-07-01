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
    public class SeedingDataSparePartsItem
    {
        private static List<SparePartsItem> Get(MaintenanceCenter center)
        {
            return new List<SparePartsItem>
            {
                new SparePartsItem
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Cảm biến lùi xe ô tô",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
                new SparePartsItem
                {
                   CreatedDate=DateTime.Now,
                   Image="https://hanoicomputercdn.com/media/product/72039_camera_hanh_trinh_xiaomi_70mai_m500_64gb__2_.jpg",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Camera hành trình",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
                new SparePartsItem
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Lọc gió xe ô tô",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
                new SparePartsItem
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Màn hình xe ô tô",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
                new SparePartsItem
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Giá màn hình xe ô tô",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
                new SparePartsItem
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Gạt mưa ô tô",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
                new SparePartsItem
                {
                   CreatedDate=DateTime.UtcNow.Date,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   SparePartsId=null,
                   SparePartsItemName = "Rèm che nắng",
                   Status=EnumStatus.ACTIVE.ToString(),
                   SparePartsItemtId=Guid.NewGuid(),
                },
            };
        }
        public static List<SparePartsItem> ServiceSeedingDataSparePartItems(ModelBuilder modelBuilder, List<MaintenanceCenter> centers)
        {
            List<SparePartsItem> spi = new List<SparePartsItem>();
            foreach (var item in centers)
            {
                spi = Get(item);
                modelBuilder.Entity<SparePartsItem>().HasData(spi);
            }
            return spi;

        }
    }
}
