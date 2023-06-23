using AutoMapper;
using CarRentalManagementSystemAPI.Services.DriverService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DriverController : ControllerBase
    {
        private  readonly IDriverService _driverSercvice;
        private readonly IMapper _mapper;

        public DriverController(IDriverService driverSercvice,IMapper mapper)
        {
            _driverSercvice = driverSercvice;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<DriverVM>?>> AddDriver([FromBody] DriverVM driver)
        {
            Driver obj = _mapper.Map<Driver>(driver);
            var result = await _driverSercvice.AddDriver(obj);
            return Ok(result.Select(div => _mapper.Map<DriverVM>(div)));
        }
        [HttpGet]
        public async Task<ActionResult<List<DriverVM>?>> GetAllDrivers()
        {
            var result = await _driverSercvice.GetAllDrivers();
            return Ok(result.Select(div => _mapper.Map<DriverVM>(div)));
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<DriverVM>?> GetDriversByName(string name)
        {
            var result = await _driverSercvice.GetDriversByName(name);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }

            return Ok(_mapper.Map<DriverVM>(result));
        }
        [HttpGet("byUniqueIdentity/{str}")]
        public async Task<ActionResult<DriverVM>?> GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(string str)
        {
            var result = await _driverSercvice.GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(str);
            if (result == null) { 
                return NotFound("Driver not exists in the database.");
            }

            return Ok(_mapper.Map<DriverVM>(result));
        }
        [HttpPut]
        public async Task<ActionResult<List<Driver>>?> UpdateDriver([FromBody]DriverVM driverVM)
        {
            Driver obj = _mapper.Map<Driver>(driverVM);
            var result = await _driverSercvice.UpdateDriver(obj);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }
            return Ok(result.Select(div => _mapper.Map<DriverVM>(div)));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Driver>>?> DeleteDriver(string str)
        {
            var result = await _driverSercvice.DeleteDriver(str);
            if (result == null)
            {
                return NotFound("Driver not exists in the database.");
            }
            return Ok(result.Select(div => _mapper.Map<DriverVM>(div)));
        }
    }
}
