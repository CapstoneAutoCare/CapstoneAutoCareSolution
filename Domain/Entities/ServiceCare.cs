﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ServiceCare
    {
        public ServiceCare()
        {
            MaintenanceServices = new HashSet<MaintenanceService>();
        }

        [Key]

        public Guid ServiceCareId { get; set; }
        public string ServiceCareName { get; set; }
        public string ServiceCareDescription { get; set; }
        public string ServiceCareType { get; set; }
        public DateTime CreatedDate { get; set; }

        public double OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid MaintananceScheduleId { get; set; }
        public MaintananceSchedule MaintananceSchedule { get; set; }
        public ICollection<MaintenanceService> MaintenanceServices { get; set; }
    }
}
