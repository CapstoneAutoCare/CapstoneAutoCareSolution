using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestFb
{
    public class UpdateFeedback
    {
        public int vote { get; set; }
        public string comment { get; set; }
    }
}
