﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintananceServices
{
    public class UpdateServies
    {
        public string ServiceCareName { get; set; }
        public string ServiceCareDescription { get; set; }
        public string ServiceCareType { get; set; }
        public float OriginalPrice { get; set; }
        public string? Image { get; set; }

        public string Status { get; set; }

    }
}
