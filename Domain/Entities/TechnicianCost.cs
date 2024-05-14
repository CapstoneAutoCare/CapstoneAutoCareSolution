using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TechnicianCost
    {
        [Key]

        public Guid TechnicialCostId { get; set; }
        public string TechnicialCostName { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public double UnitCost { get; set; }
        public double TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public InformationMaintenance InformationMaintenance { get; set; }
    }
}
