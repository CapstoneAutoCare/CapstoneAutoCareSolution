using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request
{
    public class CreateCenterPackage
    {
        public Guid PackageId { get; set; }
        public CreateTransaction CreateTransaction { get; set; }
    }
}
