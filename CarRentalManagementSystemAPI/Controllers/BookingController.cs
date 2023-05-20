using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRentalManagementSystemAPI.Services.BookingService;
namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _booking;

        public BookingController(IBookingService booking)
        {
            _booking = (BookingService)booking;
        }
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetALLBooking()
        {
            return await _booking.GetAllBooking();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Booking>>> GetBookingById(Guid id)
        {
            var result =  await _booking.GetBookingByBookingId(id);
            if(result == null)
            {
                return NotFound("Booking is not exists in database.");
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Booking>>> AddBooking(Booking booking)
        {
            return await _booking.AddBooking(booking);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Booking>>> DeleteBookingById(Guid id)
        {
            var result = await _booking.DeleteBookingByBookingId(id);
            if (result == null)
            {
                return NotFound("Booking is not exists in database.");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Booking>>> UpdateBookingById(Booking booking)
        {
            var result = await _booking.UpdateBookingByBookingId(booking);
            if (result == null)
            {
                return NotFound("Booking is not exists in database.");
            }

            return Ok(result);
        }
    }
}
