using Infrastructure.Common.Response.ResponseBooking;

namespace CapstoneAutoCareApi.Hubs
{
    public interface IBookingHubs
    {
        Task SendNotification(List<ResponseBooking> bookings);

    }
}
