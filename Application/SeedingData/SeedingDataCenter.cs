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
    public class SeedingDataCenter
    {
        private static List<MaintenanceCenter> Get()
        {
            return new List<MaintenanceCenter>
        {
                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "87B Quang Trung, Phường Hiệp Phú, Quận 9, Thành Phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 9",
                    Country="VN",
                    Rating=4.3f,
                    MaintenanceCenterDescription="Garage ô tô Vũ Khôi là nơi bảo dưỡng, sửa chữa xe ô tô được đánh giá cao tại Quận 9. Với đội ngũ nhân viên lành nghề và dịch vụ đa dạng, Garage ô tô Vũ Khôi nhận được nhiều khách hàng lựa chọn.",
                    MaintenanceCenterName="Garage Ô Tô Vũ Khôi",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center9",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "0902514161",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },
                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "86/20 Trần Hưng Đạo, P. Nguyễn Cư Trinh, Quận 1, Thành Phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 1",
                    Country="VN",
                    Rating=4.5f,
                    MaintenanceCenterDescription="Là một trong 7 garage ô tô Việt Nam nằm trong hệ thống Bosch Car Service toàn cầu, Thế Giới Auto đã dành được nhiều sự tin tưởng của các chủ xe ở Tp.HCM. Công ty chuyên về sơn nội – ngoại thất ô tô; kiểm tra, bảo dưỡng, sửa chữa điện – máy ô tô; cung cấp phụ tùng chính hãng cho các dòng xe cùng các dịch vụ khác.",
                    MaintenanceCenterName="Garage Ô Tô Hiệp",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center1",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "0903360633",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },
                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "Số 143 đường 7B, P. An Phú, TP. Thủ Đức, Thành Phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 2",
                    Country="VN",
                    Rating=4.5f,
                    MaintenanceCenterDescription="",
                    MaintenanceCenterName="Garage Auto Viet",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center2",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "0919866218",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },
                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "2/24 Nguyễn Gia Thiều, Phường 6, Quận 3, Thành Phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 3",
                    Country="VN",
                    Rating=4.5f,
                    MaintenanceCenterDescription="Sửa Ô Tô Lưu Động Sài Gòn chuyên sửa chữa, khắc phục cái lỗi hỏng xe ô tô đơn giản như vá săm thay lốp; kích, thay mới và sửa bình ắc quy; điện ô tô… Phục vụ lưu động tận nơi, 24/7 khắc phục sự cố tạm thời để xe có thể hoạt động trở lại và di chuyển tới các gara sửa ô tô chuyên nghiệp.",
                    MaintenanceCenterName="Garage Ô Tô Lưu Động Sài Gòn",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center3",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "0909668686",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },

                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "22 Tôn Thất Thuyết P.16 Q.4, Thành Phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 4",
                    Country="VN",
                    Rating=4.5f,
                    MaintenanceCenterDescription="Sửa Ô Tô Lưu Động Sài Gòn chuyên sửa chữa, khắc phục cái lỗi hỏng xe ô tô đơn giản như vá săm thay lốp; kích, thay mới và sửa bình ắc quy; điện ô tô… Phục vụ lưu động tận nơi, 24/7 khắc phục sự cố tạm thời để xe có thể hoạt động trở lại và di chuyển tới các gara sửa ô tô chuyên nghiệp.",
                    MaintenanceCenterName="Garage Ô Tô Lưu Động Sài Gòn",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center4",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "0902 757 679",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },
                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "356-358, An Dương Vương, Phường 4, Quận 5, Tp.HCM",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 5",
                    Country="VN",
                    Rating=4.5f,
                    MaintenanceCenterDescription="Garage Ô Tô Tiến Phát được nhiều khách hàng đánh giá là có đội thợ sửa chữa cứng tay nghề, sửa nhanh và cung cấp phụ tùng chất lượng – chính hãng. Ngoài ra, gara này chuyên nhất là về điện máy, nên nếu xế cưng của bạn có vấn đề về điện máy thì đây là một cái tên uy tín có thể “chọn mặt gửi vàng”.",
                    MaintenanceCenterName="Garage Ô Tô Tiến Phát",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center5",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "0974455077",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },
        };
        }
        public static List<MaintenanceCenter> ServiceSeedingDataCenter(ModelBuilder modelBuilder)
        {
            var centre = Get();
            foreach (var item in centre)
            {
                modelBuilder.Entity<MaintenanceCenter>().HasData(new
                {
                    item.MaintenanceCenterId,
                    item.CreateDate,
                    item.Address,
                    item.City,
                    item.District,
                    item.Country,
                    item.MaintenanceCenterDescription,
                    item.MaintenanceCenterName,
                    item.Rating,
                    AccountId = item.Account.AccountID
                });

                modelBuilder.Entity<Account>().HasData(new
                {
                    item.Account.AccountID,
                    item.Account.Email,
                    item.Account.Gender,
                    item.Account.Logo,
                    item.Account.Password,
                    item.Account.Role,
                    item.Account.CreatedDate,
                    item.Account.Phone,
                    item.Account.Status
                });

            }
            return centre;
        }

    }
}
