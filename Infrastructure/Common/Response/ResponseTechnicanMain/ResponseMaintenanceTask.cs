﻿using Infrastructure.Common.Response.ResponseStaffCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseTechnicanMain
{
    public class ResponseMaintenanceTask
    {
        public Guid MaintenanceTaskId { get; set; }
        public string MaintenanceTaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public Guid TechnicianId { get; set; }
        public List<ResponseMainTaskService> ResponseMainTaskServices { get; set; }
        public List<ResponseMainTaskSparePart> ResponseMainTaskSpareParts { get; set; }
        public ResponseTechnician ResponseTechnician { get; set; }
    }
}
