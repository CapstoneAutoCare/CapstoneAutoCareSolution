using Infrastructure.Common.Response.ResponseBooking;
using Microsoft.AspNetCore.SignalR;

public class NotificationHub : Hub
{
    public async Task SubscribeToNotifications(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task UnsubscribeFromNotifications(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendNotificationToGroup(string groupName, string message)
    {
        await Clients.Group(groupName).SendAsync("ReceiveNotification", message);
    }
    public async Task SendNotificationToGroupV1(string id,List<ResponseBooking> bookings)
    {
        await Clients.Group(id).SendAsync("ReceiveBookingUpdate", bookings);
    }
    public async Task SendNotificationToAll()
    {
        await Clients.All.SendAsync("ReceiveNotification", "XUANDUYmessage");
    }
    public async Task TestConnection(string groupName)
    {
        await Clients.Group(groupName).SendAsync("ReceiveNotification", "Test connection successful");
    }
}
