using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataSparePartsItemCost
    {
        static float GetRandomNumber()
        {
            Random random = new Random();

            int randomBase = random.Next(50, 1001);

            float randomNumber = randomBase * 1000;

            return randomNumber;
        }
        public static List<SparePartsItemCost> GetSparePartsItemsCost(List<SparePartsItem> sparePartsItems)
        {
            return sparePartsItems.Select(c => new SparePartsItemCost
            {
                ActuralCost = GetRandomNumber(),
                DateTime = DateTime.Now,
                SparePartsItemId = c.SparePartsItemtId,
                Note = "",
                SparePartsItemCostId = Guid.NewGuid(),
                Status = EnumStatus.ACTIVE.ToString()
            }).ToList();
        }
    }
}
