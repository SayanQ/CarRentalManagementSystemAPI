using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<Booking>> AddBooking(Booking booking);
        Task<List<Booking>?> GetAllBooking();
        Task<Booking?> GetBookingByBookingId(Guid Id);
        Task<List<Booking>?> DeleteBookingByBookingId(Guid Id);
        Task<List<Booking>?> UpdateBookingByBookingId(Booking booking);


    }
}
