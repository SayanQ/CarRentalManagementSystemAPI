using AutoMapper;
using CarRentalManagementSystemAPI.Services.PaymentService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService,IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentVM>>?> GetAllPayments()
        {
            var result = await _paymentService.GetAllPayments();
            return Ok(result.Select(payment => _mapper.Map<PaymentVM>(payment)));

        }

        [HttpGet("{type}")]
        public async Task<ActionResult<List<PaymentVM>>?> GetPaymentsByType(string type)
        {
            var result = await _paymentService.GetPaymentsByType(type);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result.Select(payment => _mapper.Map<PaymentVM>(payment)));

        }

        [HttpGet("byStatus/{paymentStatus}")]
        public async Task<ActionResult<List<PaymentVM>>?> GetPaymentByStatus(string paymentStatus)
        {
            var result = await _paymentService.GetPaymentsByStatus(paymentStatus);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result.Select(payment => _mapper.Map<PaymentVM>(payment)));
        }

        [HttpDelete("{booking_id}")]
        public async Task<ActionResult<List<PaymentVM>>?> DeletePaymentById(int booking_id)
        {
            var result = await _paymentService.DeletePaymentByBookingId(booking_id);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result.Select(payment => _mapper.Map<PaymentVM>(payment)));
        }

        [HttpPut]
        public async Task<ActionResult<List<PaymentVM>>?> UpdatePayment([FromBody] PaymentVM payment)
        {
            var obj = _mapper.Map<Payment>(payment);
            var result = await _paymentService.UpdatePaymentByBookingId(obj);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result.Select(payment => _mapper.Map<PaymentVM>(payment)));

        }

        [HttpPost]
        public async Task<ActionResult<List<PaymentVM>>?> AddPayment([FromBody]PaymentVM payment)
        {
            var obj = _mapper.Map<Payment>(payment);
            var result = await _paymentService.AddPayment(obj);
            return Ok(result.Select(payment => _mapper.Map<PaymentVM>(payment)));
        }
    }
}
