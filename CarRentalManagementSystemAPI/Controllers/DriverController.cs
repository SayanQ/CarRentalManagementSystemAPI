using CarRentalManagementSystemAPI.Services.DriverService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private  readonly DriverService _driverSercvice;

        public DriverController(IDriverService driverSercvice)
        {
            _driverSercvice = (DriverService)driverSercvice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>?>> GetAllDrivers()
        {
            return await _driverSercvice.GetAllDrivers();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Driver>?> GetDriversById(Guid id)
        {
            var result = await _driverSercvice.GetDriverByDriverId(id);
            if (result == null) { 
                return NotFound("Driver not exists in the database.");
            }

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Driver>>?> DeleteDriversById(Guid id)
        {
            var result = await _driverSercvice.DeleteDriverByDriverId(id);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Driver>>?> AddDriver([FromBody]Driver driver) { 
            var result = await _driverSercvice.AddDriver(driver);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Driver>>?> UpdateDriverById([FromBody]Driver driver)
        {
            var result = await _driverSercvice.UpdateDriverByDriverId(driver);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }
            return Ok(result);
        }
    }
}
