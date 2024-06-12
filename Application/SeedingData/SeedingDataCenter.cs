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
                    Address= "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 9",
                    Country="VN",
                    Rating=5,
                    MaintenanceCenterDescription="Gara Phi Long Ô Tô BK",
                    MaintenanceCenterName="Gara Phi Long Ô Tô BK",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center1",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "1",
                        Status=EnumStatus.ACTIVE.ToString(),
                    }
                },
                new MaintenanceCenter
                {
                    MaintenanceCenterId=Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    Address= "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh",
                    City="Thành phố Hồ Chí Minh",
                    District="Quận 9",
                    Country="VN",
                    Rating=5,
                    MaintenanceCenterDescription="Gara Phi Long Ô Tô BK",
                    MaintenanceCenterName="Gara Phi Long Ô Tô BK",
                    Account=new Account
                    {
                        AccountID=Guid.NewGuid(),
                        Email="center2",
                        Gender="1",
                        Logo="1",
                        Password= "1",
                        Role = "CENTER",
                        CreatedDate= DateTime.Now,
                        Phone= "1",
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
