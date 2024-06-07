using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public class SeedingDataCenter
    {
        public static List<MaintenanceCenter> Get()
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

        };
        }
    }
}
