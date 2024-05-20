﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceInformation
    {
        public MaintenanceInformation()
        {
            MaintenanceHistoryStatuses = new HashSet<MaintenanceHistoryStatus>();
            MaintenanceItems = new HashSet<MaintenanceItem>();
            Technicians = new HashSet<Technician>();
        }

        [Key]
        public Guid InformationMaintenanceId { get; set; }
        public string InformationMaintenanceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Note { get; set; }
        public Guid CustomerCareId { get; set; }
        public CustomerCare CustomerCare { get; set; }
        public ICollection<MaintenanceItem> MaintenanceItems { get; set; }
        public ICollection<Technician> Technicians { get; set; }
        public ICollection<MaintenanceHistoryStatus> MaintenanceHistoryStatuses { get; set; }
        public Receipt Receipt { get; set; }
        public OdoHistory OdoHistory { get; set; }

    }
}
