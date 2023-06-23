using Microsoft.AspNetCore.Mvc;
using CarRentalManagementSystemAPI.Services.BookingService;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _booking;
        private readonly IMapper _mapper;

        public BookingController(IBookingService booking, IMapper mapper)
        {
            _booking = booking;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookingVM>>> GetALLBooking()
        {
            var result = await _booking.GetAllBooking();
            return Ok(result.Select(booking => _mapper.Map<BookingVM>(booking)));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingVM>> GetBookingById(int id)
        {
            var result = await _booking.GetBookingByBookingId(id);
            if (result == null)
            {
                return NotFound("Booking is not exists in database.");
            }

            return Ok(_mapper.Map<BookingVM>(result));

        }
        [HttpPost]
        public async Task<ActionResult<List<BookingVM>>> AddBooking(BookingVM bookingVM)
        {
            Booking booking = _mapper.Map<Booking>(bookingVM);
            var result = await _booking.AddBooking(booking);

            return Ok(result.Select(b => _mapper.Map<BookingVM>(b)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BookingVM>>> DeleteBookingById(int id)
        {
            var result = await _booking.DeleteBookingByBookingId(id);
            if (result == null)
            {
                return NotFound("Booking is not exists in database.");
            }

            return Ok(result.Select(booking => _mapper.Map<BookingVM>(booking)));
        }

        [HttpPut("{bookingId}")]
        public async Task<ActionResult<List<BookingVM>>> UpdateBookingById(int bookingId,[FromBody]BookingVM bookingVM)
        {
            Booking booking = _mapper.Map<Booking>(bookingVM);

            var result = await _booking.UpdateBookingByBookingId(bookingId, booking);
            if (result == null)
            {
                return NotFound("Booking is not exists in database.");
            }

            return Ok(result.Select(b => _mapper.Map<BookingVM>(b)));
        }
    }
}
