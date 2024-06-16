﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceServiceCost
    {
        public MaintenanceServiceCost()
        {
        }
        [Key]
        public Guid MaintenanceServiceCostId { get; set; }
        public double ActuralCost { get; set; }
        public DateTime DateTime { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public Guid MaintenanceServiceId { get; set; }
        public MaintenanceService MaintenanceService { get; set; }

    }
}