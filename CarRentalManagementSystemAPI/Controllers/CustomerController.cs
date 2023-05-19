using CarRentalManagementSystemAPI.Models;
using CarRentalManagementSystemAPI.Services.CarService;
using CarRentalManagementSystemAPI.Services.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>?>> GetAllCustomers()
        {
            return await _customerService.GetAllCustomers();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Customer>?>> GetCustomerByCustomerId(Guid Id)
        {
            var result = await _customerService.GetCustomerByCustomerId(Id);

            if(result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Customer>?>> DeleteCustomerByCustomerId(Guid Id)
        {
            var result = await _customerService.DeleteCustomerByCustomerId(Id);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer([FromBody]Customer customer)
        {
            var result = await _customerService.AddCustomer(customer);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>?>> UpdateCustomerByCustomerId([FromBody] Customer customer)
        {
            var result = await _customerService.UpdateCustomerByCustomerId(customer);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result);

        }




    }
}
