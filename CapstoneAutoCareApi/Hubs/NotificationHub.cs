using Infrastructure.Common.Response.ResponseBooking;
using Microsoft.AspNetCore.SignalR;

namespace CapstoneAutoCareApi.Hubs
{
    public class NotificationHub : Hub<IBookingHubs>, IBookingHubs
    {


        public async Task SendNotification(List<ResponseBooking> bookings)
        {
            await Clients.All.SendNotification(bookings);
        }
    }
}
