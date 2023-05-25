using AutoMapper;
using CarRentalManagementSystemAPI.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeVM>?>> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployees();
            return Ok(result.Select(emp => _mapper.Map<EmployeeVM>(emp)));
        }

        [HttpGet("{str}")]
        public async Task<ActionResult<EmployeeVM>?> GetEmployeeByPhoneNoOrEmailOrAadharOrPan(string str)
        {
            var result = await _employeeService.GetEmployeeByPhoneNoOrEmailOrAadharOrPan(str);

            if (result == null) {
                return NotFound("Employee doesn't exist in databse");

            }

            return Ok(_mapper.Map<EmployeeVM>(result));

        }

        [HttpPost]
        public async Task<ActionResult<List<EmployeeVM>>> AddEmployee([FromBody] EmployeeVM employeeVM)
        {
            Employee obj = _mapper.Map<Employee>(employeeVM);
            var result = await _employeeService.AddEmployee(obj);

            return Ok(result.Select(emp => _mapper.Map<EmployeeVM>(emp)));
        }

        [HttpPut]
        public  async Task<ActionResult<List<EmployeeVM>>> UpdateEmployeeById(EmployeeVM employeeVM)
        {
            Employee obj = _mapper.Map<Employee>(employeeVM);
            var result = await _employeeService.UpdateEmployee(obj);

            if (result == null) {
                return NotFound("Employee doesn't exist in databse");
            }

            return Ok(result.Select(emp => _mapper.Map<EmployeeVM>(emp)));
        }

        [HttpDelete("{str}")]
        public async Task<ActionResult<List<EmployeeVM>>?> DeleteEmployee(string str)
        {
            var result = await _employeeService.DeleteEmployee(str);
            if (result == null) { 
                return NotFound("Employee doesn't exist in databse");
            }
            return Ok(result.Select(emp => _mapper.Map<EmployeeVM>(emp)));
        }

    }
}
