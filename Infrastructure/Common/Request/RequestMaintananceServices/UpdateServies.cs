using System;
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
        public double OriginalPrice { get; set; }
    }
}
