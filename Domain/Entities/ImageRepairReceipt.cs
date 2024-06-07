﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImageRepairReceipt
    {
        public ImageRepairReceipt()
        {
        }

        public Guid ImageRepairReceiptId { get; set; }
        public string? Image { get; set; }
        public DateTime Created { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public Guid VehicleId { get; set; }
        public Guid? MaintenanceCenterId { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Vehicles Vehicle { get; set; }
    }
}
