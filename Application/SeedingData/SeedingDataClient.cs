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
    public class SeedingDataClient
    {
        private static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = Guid.NewGuid(),
                    Birthday = DateTime.Now,
                    Address = "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh",
                    FirstName = "P",
                    LastName = "D",

                    Account = new Account
                    {
                        AccountID = Guid.NewGuid(),
                        Email = "c1",
                        Gender = "1",
                        Logo = "1",
                        Password = "1",
                        Role = "CUSTOMER",
                        CreatedDate = DateTime.Now,
                        Phone = "1",
                        Status = EnumStatus.ACTIVE.ToString(),
                    }
                },
                new Client
                {
                    ClientId = Guid.NewGuid(),
                    Birthday = DateTime.Now,
                    Address = "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh",
                    FirstName = "F",
                    LastName = "L",
                    Account = new Account
                    {
                        AccountID = Guid.NewGuid(),
                        Email = "c2",
                        Gender = "1",
                        Logo = "1",
                        Password = "1",
                        Role = "CUSTOMER",
                        CreatedDate = DateTime.Now,
                        Phone = "1",
                        Status = EnumStatus.ACTIVE.ToString(),
                    }
                },
            };
        }
        public static List<Client> ServiceSeedingDataClient(ModelBuilder modelBuilder)
        {
            var clients = Get();
            foreach (var item in clients)
            {
                modelBuilder.Entity<Client>().HasData(new
                {
                    item.ClientId,
                    item.Birthday,
                    item.FirstName,
                    item.Address,
                    item.LastName,
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
            return clients;
        }
    }

}