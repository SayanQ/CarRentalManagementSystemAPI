using CarRentalManagementSystemAPI.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = (EmployeeService)employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeVM>?>> GetAllEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        [HttpGet("{str}")]
        public async Task<ActionResult<EmployeeVM>?> GetEmployeeByPhoneNoOrEmailOrAadharOrPan(string str)
        {
            var result = await _employeeService.GetEmployeeByPhoneNoOrEmailOrAadharOrPan(str);

            if (result == null) {
                return NotFound("Employee doesn't exist in databse");

            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<List<EmployeeVM>>> AddEmployee([FromBody] EmployeeVM e)
        {
            var result = await _employeeService.AddEmployee(e);
            return Ok(result);
        }

        [HttpPut]
        public  async Task<ActionResult<List<EmployeeVM>>> UpdateEmployeeById(EmployeeVM employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            if (result == null) {
                return NotFound("Employee doesn't exist in databse");
            }

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<EmployeeVM>>?> DeleteEmployee(string str)
        {
            var result = await _employeeService.DeleteEmployee(str);
            if (result == null) { 
                return NotFound("Employee doesn't exist in databse");
            }
            return Ok(result);
        }

    }
}
