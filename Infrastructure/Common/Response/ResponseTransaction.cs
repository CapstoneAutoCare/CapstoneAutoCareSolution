using Domain.Entities;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.MaintenancePlanResponse;
using Infrastructure.Common.Response.VehiclesResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response
{
    public class ResponseTransaction
    {
        public Guid TransactionsId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public Guid MaintenancePlanId { get; set; }
        public Guid VehiclesId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Volume { get; set; }
        public string? Description { get; set; }

        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public ResponseVehicles ResponseVehicles { get; set; }
        public ResponseCenter ResponseCenter { get; set; }
        public ResponseMaintenancePlan ResponseMaintenancePlan { get; set; }
    }
}
