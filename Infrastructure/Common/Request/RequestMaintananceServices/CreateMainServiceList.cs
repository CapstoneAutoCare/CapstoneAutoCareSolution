﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintananceServices
{
    public class CreateMainServiceList
    {
        public List<Guid>? ServiceCareIds {  get; set; }
    }
}
