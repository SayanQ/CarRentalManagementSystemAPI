using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<BookingVM>?> AddBooking(BookingVM booking);
        Task<List<BookingVM>?> GetAllBooking();
        Task<Booking?> GetBookingByBookingId(Guid Id);
        Task<List<BookingVM>?> DeleteBookingByBookingId(Guid Id);
        Task<List<BookingVM>?> UpdateBookingByBookingId(Booking booking);


    }
}
