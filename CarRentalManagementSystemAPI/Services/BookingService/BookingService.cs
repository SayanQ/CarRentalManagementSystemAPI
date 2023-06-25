namespace CarRentalManagementSystemAPI.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;

        }
        public async Task<List<Booking>?> AddBooking(Booking booking)
        {            
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return await GetAllBooking();
        }

        public async Task<List<Booking>?> DeleteBookingByBookingId(int id)
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

        public async Task<List<Booking>?> GetAllBooking()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return bookings;
        }

        public async Task<Booking?> GetBookingByBookingId(int id)
        {
            var findBooking = await _context.Bookings.FindAsync(id);
            if (findBooking == null)
            {
                return null;
            }

            return findBooking;
        }

        public async Task<int?> GetBookingID(int carId, int customerId, int driverId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.CarId == carId && b.CustomerId == customerId && b.DriverId == driverId);
            return booking.Id;
        }

        public async Task<List<Booking>?> UpdateBookingByBookingId(int id, Booking booking)
        {
            var findBooking = await _context.Bookings.FindAsync(id);
            if (findBooking == null)
            {
                return null;
            }

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
