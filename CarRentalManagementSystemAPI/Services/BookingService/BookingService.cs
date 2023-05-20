namespace CarRentalManagementSystemAPI.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _context;

        public BookingService(DataContext context)
        {
            _context = context;

        }
        public async Task<List<Booking>> AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return await GetAllBooking();
        }

        public async Task<List<Booking>?> DeleteBookingByBookingId(Guid id)
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
            return await _context.Bookings.ToListAsync();
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

        public async Task<List<Booking>?> UpdateBookingByBookingId(Booking booking)
        {
            var findBooking = await _context.Bookings.FindAsync(booking.Id);
            if (findBooking == null)
            {
                return null;
            }

            findBooking.Id = booking.Id;
            findBooking.C_Id = booking.C_Id;
            findBooking.D_Id = booking.D_Id;
            findBooking.C_No = booking.C_No;
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
