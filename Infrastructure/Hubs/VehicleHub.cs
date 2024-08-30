using Domain.Entities;
using Infrastructure.Common.Response.VehiclesResponse;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public class VehicleHub :Hub
    {
        public async Task SendOdoUpdate(Guid vehicleId, int newOdoValue)
        {
            // Notify all connected clients about the odometer update for the specified vehicle
            await Clients.All.SendAsync("ReceiveOdoUpdate", vehicleId, newOdoValue);
        }
    }
}
