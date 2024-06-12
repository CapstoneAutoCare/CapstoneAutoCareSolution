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
    public class SeedingDataCustomerCare
    {
        private static List<CustomerCare> Get(MaintenanceCenter center)
        {
            return new List<CustomerCare>
            {
                new CustomerCare
                {
                    CustomerCareId = Guid.NewGuid(),
                    Birthday = DateTime.Now,
                    Address = "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh",
                    FirstName = "P",
                    LastName = "D",
                    CenterId =center.MaintenanceCenterId,
                    Account = new Account
                    {
                        AccountID = Guid.NewGuid(),
                        Email = "cs1",
                        Gender = "1",
                        Logo = "1",
                        Password = "1",
                        Role = "CUSTOMERCARE",
                        CreatedDate = DateTime.Now,
                        Phone = "1",
                        Status = EnumStatus.ACTIVE.ToString(),
                    }
                },
                new CustomerCare
                {
                    CustomerCareId = Guid.NewGuid(),
                    Birthday = DateTime.Now,
                    Address = "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh",
                    FirstName = "F",
                    LastName = "L",
                    CenterId =center.MaintenanceCenterId,
                    Account = new Account
                    {
                        AccountID = Guid.NewGuid(),
                        Email = "cs2",
                        Gender = "1",
                        Logo = "1",
                        Password = "1",
                        Role = "CUSTOMERCARE",
                        CreatedDate = DateTime.Now,
                        Phone = "1",
                        Status = EnumStatus.ACTIVE.ToString(),
                    }
                },
            };
        }
    }
}
