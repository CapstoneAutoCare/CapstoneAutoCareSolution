using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataServicesItem
    {
        public static List<ServiceCares> GetServicesItem(List<MaintananceSchedule> maintananceSchedules)
        {
            var servicesItemName = new[] {
                "Thay lọc nhớt máy",
                "Thay lọc nhớt",
                "Vệ sinh khoang động cơ" ,
                //"Vệ sinh bộ lọc không khí" ,
                //"Vệ sinh lốp và bánh xe" ,
                //"Bảo trì và kiểm tra hệ thống điều hòa" ,
                //"Vệ sinh dàn lạnh" ,
                //"Thay lốp" ,
                //"Cân bằng và căn chỉnh bánh xe" ,
                //"Kiểm tra và sửa chữa động cơ" ,
                //"Sửa chữa hệ thống phanh" ,
                //"Sửa chữa và thay thế bộ phận xả" ,
                //"Cứu hộ và sửa chữa trên đường" ,
                //"Kiểm tra định kỳ" ,
            };
            var servicesItemDescription = new[] {
                "Thay Lọc Nhớt Máy",
                "Thay Lọc Nhớt",
                "Vệ Sinh Khoang Động Cơ",
            };
            var services = new List<ServiceCares>();
            foreach (var schedule in maintananceSchedules)
            {
                for (int i = 0; i < servicesItemName.Length; i++)
                {

                    services.Add(new ServiceCares
                    {
                        CreatedDate = DateTime.Now,
                        MaintananceScheduleId = schedule.MaintananceScheduleId,
                        ServiceCareId = Guid.NewGuid(),
                        OriginalPrice = 100000,
                        ServiceCareName = servicesItemName[i],
                        ServiceCareType = servicesItemName[i],
                        ServiceCareDescription = servicesItemDescription[i],
                        Status = EnumStatus.ACTIVE.ToString(),
                        Image=null,
                    });
                }
            }
            return services;

        }

    }
}
