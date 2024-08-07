﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenanceSparePart
{
    public class ResponseMaintenanceSparePartInfo
    {
        public Guid MaintenanceSparePartInfoId { get; set; }
        public string MaintenanceSparePartInfoName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public float ActualCost { get; set; }
        public float TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Image {  get; set; }
        public Guid? SparePartsItemId { get; set; }

        public Guid? SparePartsItemCostId { get; set; }
        public Guid InformationMaintenanceId { get; set; }
    }
}
