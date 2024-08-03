using Domain.Entities;

namespace CapstoneAutoCareApi.Hub.Bookings
{
    public interface IBookingHub
    {
        Task ReceiptBookingHub(Booking booking);
    }
}
