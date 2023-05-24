using CarRentalManagementSystemAPI.Services.DriverService;
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

        [HttpPost]
        public async Task<ActionResult<List<Driver>>?> AddDriver([FromBody] DriverVM driver)
        {
            var result = await _driverSercvice.AddDriver(driver);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<DriverVM>?>> GetAllDrivers()
        {
            return await _driverSercvice.GetAllDrivers();
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Driver>?> GetDriversByName(string name)
        {
            var result = await _driverSercvice.GetDriversByName(name);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }

            return Ok(result);
        }
        [HttpGet("{str}")]
        public async Task<ActionResult<Driver>?> GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(string str)
        {
            var result = await _driverSercvice.GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(str);
            if (result == null) { 
                return NotFound("Driver not exists in the database.");
            }

            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<List<Driver>>?> UpdateDriver([FromBody]DriverVM driver)
        {
            var result = await _driverSercvice.UpdateDriver(driver);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Driver>>?> DeleteDriver(string str)
        {
            var result = await _driverSercvice.DeleteDriver(str);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }
            return Ok(result);
        }
    }
}
