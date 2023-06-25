using AutoMapper;
using CarRentalManagementSystemAPI.Services.CustomerService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerVM>?>> GetAllCustomers()
        {
            var result = await _customerService.GetAllCustomers();
            return Ok(result.Select(cust => _mapper.Map<CustomerVM>(cust)));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<CustomerVM>?>> GetCustomersByName(string name)
        {
            var result = await _customerService.GetCustomersByName(name);

            if(result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result.Select(cust => _mapper.Map<CustomerVM>(cust)));

        }

        [HttpGet("byUniqueIdentity/{str}")]
        public async Task<ActionResult<List<CustomerVM>?>> GetCustomerByPhoneNoOrEmailOrAadharOrPan
(string str)
        {
            var result = await _customerService.GetCustomerByPhoneNoOrEmailOrAadharOrPan
(str);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(_mapper.Map<CustomerVM>(result));

        }

        [HttpDelete("{str}")]
        public async Task<ActionResult<List<CustomerVM>?>> DeleteCustomer(string str)
        {
            var result = await _customerService.DeleteCustomer(str);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result.Select(cust => _mapper.Map<CustomerVM>(cust)));
        }

        [HttpPost]
        public async Task<ActionResult<List<CustomerVM>>> AddCustomer([FromBody]CustomerVM customer)
        {
            Customer obj = _mapper.Map<Customer>(customer);
            var result = await _customerService.AddCustomer(obj);
            return Ok(result.Select(cust => _mapper.Map<CustomerVM>(cust)));
        }

        [HttpPut]
        public async Task<ActionResult<List<CustomerVM>?>> UpdateCustomer([FromBody]CustomerVM customer)
        {
            Customer obj = _mapper.Map<Customer>(customer);
            var result = await _customerService.UpdateCustomer(obj);

            if (result == null)
                return NotFound("Customer doesn't exists in the database.");

            return Ok(result.Select(cust => _mapper.Map<CustomerVM>(cust)));
        }

        [HttpGet]
        [Route("forBooking/{customer_phone_no}")]
        public async Task<ActionResult<int>> GetDriverIDByPhoneNo(string customer_phone_no)
        {
            var result = await _customerService.GetCustomerIDByPhoneNo(customer_phone_no);


            if (result == 0)
                return NotFound("Driver doesn't exist in databse");

            return Ok(result);
        }


    }
}
