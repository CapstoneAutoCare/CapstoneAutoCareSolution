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
    public class SeedingDataMaintenanceService
    {
        private static List<MaintenanceService> Get(MaintenanceCenter center)
        {
            return new List<MaintenanceService>
            {
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Chăm sóc nội thất bằng máy nước nóng",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://hanoicomputercdn.com/media/product/72039_camera_hanh_trinh_xiaomi_70mai_m500_64gb__2_.jpg",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Chăm sóc khoang máy",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Chăm sóc khoang máy",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Phủ Ceramic bảo vệ sơn",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Làm sạch bề mặt sơn",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Tẩy bụi sơn công nghiệp",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
                new MaintenanceService
                {
                   CreatedDate=DateTime.Now,
                   Image="https://dochoiotogiare.com/wp-content/uploads/2018/09/cam-bien-lui-va-canh-bao-va-cham10.png",
                   MaintenanceCenterId=center.MaintenanceCenterId,
                   ServiceCareId=null,
                   MaintenanceServiceName = "Chăm sóc kính",
                   Status=EnumStatus.ACTIVE.ToString(),
                   MaintenanceServiceId=Guid.NewGuid(),
                },
            };
        }
        public static List<MaintenanceService> ServiceSeedingDataMaintenanceService(ModelBuilder modelBuilder, List<MaintenanceCenter> centers)
        {
            List<MaintenanceService> spi = new List<MaintenanceService>();
            foreach (var item in centers)
            {
                spi = Get(item);
                modelBuilder.Entity<MaintenanceService>().HasData(spi);
            }
            return spi;

        }
    }
}
