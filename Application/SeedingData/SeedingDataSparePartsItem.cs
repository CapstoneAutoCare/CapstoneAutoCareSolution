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
    public partial class SeedingDataSparePartsItem
    {
        public static List<SparePartsItem> GetSparePartsItems(List<MaintenanceCenter> centers, List<SpareParts> spareParts)
        {
            return centers.AsParallel().SelectMany(center =>
                spareParts.Select(sparePart => new SparePartsItem
                {
                    SparePartsItemtId = Guid.NewGuid(),
                    Status = EnumStatus.ACTIVE.ToString(),
                    SparePartsItemName = sparePart.SparePartName,
                    CreatedDate = DateTime.Now,
                    Image = "",
                    Capacity = 5,
                    SparePartsId = sparePart.SparePartId,
                    MaintenanceCenterId = center.MaintenanceCenterId,
                })
            ).ToList();
        }
    }
}
