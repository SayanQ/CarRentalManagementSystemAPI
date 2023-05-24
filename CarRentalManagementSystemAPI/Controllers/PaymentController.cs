using CarRentalManagementSystemAPI.Services.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentVM>>?> GetAllPayments()
        {
            return await _paymentService.GetAllPayments();
        }

        [HttpGet("{type}")]
        public async Task<ActionResult<List<PaymentVM>>?> GetPaymentsByType(string type)
        {
            var result = await _paymentService.GetPaymentsByType(type);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpGet("byStatus/{paymentStatus}")]
        public async Task<ActionResult<List<PaymentVM>>?> GetPaymentByStatus(bool status)
        {
            var result = await _paymentService.GetPaymentsByStatus(status);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PaymentVM>>?> DeletePaymentById(int id)
        {
            var result = await _paymentService.DeletePaymentByBookingId(id);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Payment>>?> UpdatePayment([FromBody] PaymentVM payment)
        {
            var result = await _paymentService.UpdatePaymentBookingId(payment);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<PaymentVM>>?> AddPayment([FromBody]PaymentVM payment)
        {
            var result = await _paymentService.AddPayment(payment);
            return Ok(result);
        }
    }
}
