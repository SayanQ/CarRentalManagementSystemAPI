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
        public async Task<ActionResult<List<CustomerVM>?>> GetAllCustomers()
        {
            return await _customerService.GetAllCustomers();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Customer>?>> GetCustomersByName(string name)
        {
            var result = await _customerService.GetCustomersByName(name);

            if(result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Customer>?>> DeleteCustomerByPhoneNo(string phone)
        {
            var result = await _customerService.DeleteCustomerByPhoneNo(phone);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer([FromBody]CustomerVM customer)
        {
            var result = await _customerService.AddCustomer(customer);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>?>> UpdateCustomer([FromBody]CustomerVM customer)
        {
            var result = await _customerService.UpdateCustomer(customer);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result);

        }




    }
}
