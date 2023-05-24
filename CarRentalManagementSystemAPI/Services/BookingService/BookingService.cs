using CarRentalManagementSystemAPI.Models;
using CarRentalManagementSystemAPI.ViewModels;

namespace CarRentalManagementSystemAPI.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;

        }
        public async Task<List<BookingVM>?> AddBooking(BookingVM booking)
        {
            var _booking = new Booking()
            {
                CarId = booking.CarId,
                DriverId = booking.DriverId,
                CustomerId = booking.CustomerId,
                Booking_Date_Time = booking.Booking_Date_Time,
                Rental_Start_Date_Time = booking.Rental_Start_Date_Time,
                Rental_End_Date_Time = booking.Rental_End_Date_Time,
                Pick_Up_Location = booking.Pick_Up_Location,
                Drop_Off_Location = booking.Drop_Off_Location
            };

            _context.Bookings.Add(_booking);
            await _context.SaveChangesAsync();

            return await GetAllBooking();
        }

        public async Task<List<BookingVM>?> DeleteBookingByBookingId(Guid id)
        {
            var findBooking = await _context.Bookings.FindAsync(id);
            if (findBooking == null)
            {
                return null;
            }

            _context.Bookings.Remove(findBooking);  
            await _context.SaveChangesAsync();

            return await GetAllBooking();
        }

        public async Task<List<BookingVM>?> GetAllBooking()
        {
            var bookings = await _context.Bookings.ToListAsync();

            List<BookingVM> result = new List<BookingVM>();

            foreach (var booking in bookings)
            {
                var obj = new BookingVM()
                {
                    CarId = booking.CarId,
                    DriverId = booking.DriverId,
                    CustomerId = booking.CustomerId,
                    Booking_Date_Time = booking.Booking_Date_Time,
                    Rental_Start_Date_Time = booking.Rental_Start_Date_Time,
                    Rental_End_Date_Time = booking.Rental_End_Date_Time,
                    Pick_Up_Location = booking.Pick_Up_Location,
                    Drop_Off_Location = booking.Drop_Off_Location
                };

                result.Add(obj);
            }
            return result;
        }

        public async Task<Booking?> GetBookingByBookingId(Guid id)
        {
            var findBooking = await _context.Bookings.FindAsync(id);
            if (findBooking == null)
            {
                return null;
            }

            return findBooking;
        }

        public async Task<List<BookingVM>?> UpdateBookingByBookingId(Booking booking)
        {
            var findBooking = await _context.Bookings.FindAsync(booking.Id);
            if (findBooking == null)
            {
                return null;
            }

            findBooking.Id = booking.Id;
            findBooking.CarId = booking.CarId;
            findBooking.DriverId = booking.DriverId;
            findBooking.CustomerId = booking.CustomerId;
            findBooking.Booking_Date_Time = booking.Booking_Date_Time;
            findBooking.Rental_Start_Date_Time = booking.Rental_Start_Date_Time;
            findBooking.Rental_End_Date_Time = booking.Rental_End_Date_Time;
            findBooking.Pick_Up_Location = booking.Pick_Up_Location;
            findBooking.Drop_Off_Location = booking.Drop_Off_Location;

            await _context.SaveChangesAsync();

            return await GetAllBooking();
        }
    }
}
