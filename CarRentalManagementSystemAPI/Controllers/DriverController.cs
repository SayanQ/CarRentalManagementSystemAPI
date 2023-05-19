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
    }
}
