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
                "Thay lọc gió động cơ",
                "Thay lọc gió điều hòa",
                //"Kiểm tra hệ thống lái",
                //"Kiểm tra hệ thống treo",
                //"Dịch vụ kiểm tra khí thải" ,
                //"Kiểm tra và thay dầu hộp số" ,
                //"Kiểm tra hệ thống điện" ,
                //"Vệ sinh khoang động cơ" ,
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
                "Thực hiện định kỳ theo khuyến nghị của nhà sản xuất.",
                "Thực hiện định kỳ theo khuyến nghị của nhà sản xuất",
                //"Đảm bảo không có hiện tượng rơ lỏng hay bất thường.",
                //"Đánh giá tình trạng lò xo và giảm chấn.",
                //"Đảm bảo xe đáp ứng tiêu chuẩn khí thải." ,
                //"Để đảm bảo hộp số hoạt động trơn tru." ,
                //"Kiểm tra ắc quy, máy phát điện và các mạch điện." ,
                //"Giúp phát hiện rò rỉ dầu và tạp chất." ,
                //"Để đảm bảo không khí vào động cơ luôn sạch." ,
                //"Bảo trì và kiểm tra hệ thống điều hòa" ,
                //"Giúp duy trì độ bám và tăng tuổi thọ lốp." ,
                //"Bao gồm kiểm tra gas và các bộ phận khác." ,
                //"Để đảm bảo hiệu suất làm mát." ,
                //"Khi lốp mòn hoặc hỏng." ,
                //"Để khắc phục các vấn đề như rò rỉ dầu, tiếng động lạ, hay mất công suất." ,
                //"Bao gồm thay thế các bộ phận hỏng hóc." ,
                //"Đảm bảo hệ thống xả hoạt động tốt." ,
                //"Cung cấp dịch vụ khi xe bị hỏng giữa đường." ,
                //"Để đảm bảo xe đủ điều kiện lưu thông theo quy định của pháp luật." ,
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
                    });
                }
            }
            return services;

        }

    }
}
