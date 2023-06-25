using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<Booking>?> AddBooking(Booking booking);
        Task<List<Booking>?> GetAllBooking();
        Task<Booking?> GetBookingByBookingId(int Id);
        Task<List<Booking>?> DeleteBookingByBookingId(int Id);
        Task<List<Booking>?> UpdateBookingByBookingId(int id,Booking booking);

        Task<int?> GetBookingID(int carId, int customerId, int driverId);


    }
}
