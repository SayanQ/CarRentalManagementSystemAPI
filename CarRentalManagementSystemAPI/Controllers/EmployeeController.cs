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
        public async Task<ActionResult<List<Employee>?>> GetAllEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>?> GetEmployeeById(Guid Id)
        {
            var result = await _employeeService.GetEmployeeByEmployeeId(Id);

            if (result == null) {
                return NotFound("Employee doesn't exist in databse");

            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee([FromBody] Employee e)
        {
            var result = await _employeeService.AddEmployee(e);
            return Ok(result);
        }

        [HttpPut]
        public  async Task<ActionResult<List<Employee>>> UpdateEmployeeById(Employee employee)
        {
            var result = await _employeeService.UpdateEmployeeByEmployeeId(employee);
            if (result == null) {
                return NotFound("Employee doesn't exist in databse");
            }

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Employee>>?> DeleteEmployeeById(Guid Id)
        {
            var result = await _employeeService.DeleteEmployeeByEmployeeId(Id);
            if (result == null) { 
                return NotFound("Employee doesn't exist in databse");
            }
            return Ok(result);
        }

    }
}
