using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SpareParts
    {
        public SpareParts()
        {
            SparePartsItems = new HashSet<SparePartsItem>();
        }

        [Key]

        public Guid SparePartId { get; set; }
        public string SparePartName { get; set; }
        public string SparePartDescription { get; set; }
        public string SparePartType { get; set; }
        public DateTime CreatedDate { get; set; }
        public double OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid MaintananceScheduleId { get; set; }
        public MaintananceSchedule MaintananceSchedule { get; set; }
        public ICollection<SparePartsItem> SparePartsItems { get; set; }
    }
}
