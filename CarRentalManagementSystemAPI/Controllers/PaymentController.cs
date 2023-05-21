using CarRentalManagementSystemAPI.Services.PaymentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = (PaymentService)paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetAllPayments()
        {
            return await _paymentService.GetAllPayments();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Payment?>> GetPaymentById(Guid Id)
        {
            var result = await _paymentService.GetPaymentBYId(Id);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Payment?>> DeletePaymentById(Guid Id)
        {
            var result = await _paymentService.DeletePaymentBYId(Id);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Payment?>> UpdatePayment([FromBody] Payment payment)
        {
            var result = await _paymentService.UpdatePaymentBYId(payment);
            if (result == null)
            {
                return NotFound("Payment doesn't exist in databse");

            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Payment?>> AddPayment([FromBody]Payment payment)
        {
            var result = await _paymentService.AddPayment(payment);
            return Ok(result);
        }
    }
}
