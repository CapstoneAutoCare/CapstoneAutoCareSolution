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
    public partial class SeedingDataCenter
    {
        private static Random random = new Random();

        private static string GenerateRandomEmail()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var emailLength = random.Next(5, 15);
            var emailName = new StringBuilder();

            for (int i = 0; i < emailLength; i++)
            {
                emailName.Append(chars[random.Next(chars.Length)]);
            }

            return emailName.ToString() + "@gmail.com";
        }
        private static string GenerateRandomGender()
        {
            return random.Next(0, 2) == 0 ? "Nam" : "Nữ"; 
        }
        private static string GenerateRandomPhone()
        {
            const string digits = "0123456789";
            var phoneNumber = new StringBuilder("09");

            for (int i = 2; i < 10; i++)
            {
                phoneNumber.Append(digits[random.Next(digits.Length)]);
            }

            return phoneNumber.ToString();
        }

        private static MaintenanceCenter CreateMaintenanceCenter(string address, string district, string description, string name, float rating)
        {
            return new MaintenanceCenter
            {
                MaintenanceCenterId = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Address = address,
                City = "Thành phố Hồ Chí Minh",
                District = district,
                Country = "VN",
                Rating = rating,
                MaintenanceCenterDescription = description,
                MaintenanceCenterName = name,
                Account = new Account
                {
                    AccountID = Guid.NewGuid(),
                    Email = GenerateRandomEmail(),
                    Gender = GenerateRandomGender(),
                    Logo = "",
                    Password = "1",
                    Role = "CENTER",
                    CreatedDate = DateTime.Now,
                    Phone = GenerateRandomPhone(),
                    Status = EnumStatus.ACTIVE.ToString(),
                }
            };
        }

        private static List<MaintenanceCenter> GetMaintenanceCenters()
        {
            return new List<MaintenanceCenter>
            {
                //CreateMaintenanceCenter("87B Quang Trung, Phường Hiệp Phú, Quận 9", "Quận 9",
                //    "Garage ô tô Vũ Khôi là nơi bảo dưỡng, sửa chữa xe ô tô được đánh giá cao tại Quận 9.",
                //    "Garage Ô Tô Vũ Khôi", 4.3f),
                //CreateMaintenanceCenter("86/20 Trần Hưng Đạo, P. Nguyễn Cư Trinh, Quận 1", "Quận 1",
                //    "Là một trong 7 garage ô tô Việt Nam nằm trong hệ thống Bosch Car Service toàn cầu.",
                //    "Garage Ô Tô Hiệp", 4.5f),
                //CreateMaintenanceCenter("Số 143 đường 7B, P. An Phú, TP. Thủ Đức", "Quận 2",
                //    "", "Garage Auto Viet", 4.5f),
                CreateMaintenanceCenter("2/24 Nguyễn Gia Thiều, Phường 6, Quận 3", "Quận 3",
                    "Sửa Ô Tô Lưu Động Sài Gòn chuyên sửa chữa, khắc phục cái lỗi hỏng xe ô tô đơn giản.",
                    "Garage Ô Tô Lưu Động Sài Gòn", 4.5f),
                CreateMaintenanceCenter("22 Tôn Thất Thuyết P.16 Q.4", "Quận 4",
                    "Sửa Ô Tô Lưu Động Sài Gòn chuyên sửa chữa, khắc phục cái lỗi hỏng xe ô tô đơn giản.",
                    "Garage Ô Tô Lưu Động Sài Gòn", 4.5f),
                CreateMaintenanceCenter("356-358, An Dương Vương, Phường 4, Quận 5", "Quận 5",
                    "Garage Ô Tô Tiến Phát được nhiều khách hàng đánh giá là có đội thợ sửa chữa cứng tay nghề.",
                    "Garage Ô Tô Tiến Phát", 4.5f)
            };
        }
        public static List<MaintenanceCenter> ServiceSeedingDataCenter(ModelBuilder modelBuilder)
        {
            var centres = GetMaintenanceCenters();
            foreach (var item in centres)
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
            return centres;
        }
    }

}

