using CarRentalManagementSystemAPI.Services.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper, ILogger<CarController> logger){
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
        }

         

        //Return all cars
        [HttpGet]//for sending response to the swagger 
        public async Task<ActionResult<List<CarVM>?>> GetAllCars()
        {
            _logger.LogTrace("Log message from trace method");
            _logger.LogDebug("Log message from Debug method");
            _logger.LogInformation("Log message from Information method");
            _logger.LogWarning("Log message from Warning method");
            _logger.LogError("Log message from Error method");
            _logger.LogCritical("Log message from Critical method");

            var result = await _carService.GetAllCars();
            return Ok(result.Select(c => _mapper.Map<CarVM>(c)));
        }

        //Return cars by car no
        [HttpGet]
        [Route("{Car_No}")]//telling swagger for getting the car_no from user
        public async Task<ActionResult<CarVM>> GetCarByCarNo(string Car_No)
        {
            var result = await _carService.GetCarByCarNo(Car_No);

            if (result == null)
                return NotFound("Car doesn't exist in databse");

            return Ok(_mapper.Map<CarVM>(result));
        }

        [HttpGet("byModel/{model}")]
        public async Task<ActionResult<List<CarVM>>> GetCarByModel(string model)
        {
            var result = await _carService.GetCarsByModel(model);

            if (result == null)
                return NotFound("Car doesn't exist in databse");

            return Ok(result.Select(c => _mapper.Map<CarVM>(c)));
        }

        //Add car in the cars
        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar([FromBody]CarVM carVM)//telling the method that input will be getting from the body
        {
            var carObj = _mapper.Map<Car>(carVM);
            var result = await _carService.AddCar(carObj);

            return Ok(result.Select(c => _mapper.Map<CarVM>(c)));

        }

        //Update cars by car no
        [HttpPut]
        public async Task<ActionResult<List<CarVM>>> UpdateCarByCarNo([FromBody]CarVM carVM)
        {
            var carObj = _mapper.Map<Car>(carVM);

            var result = await _carService.UpdateCarByCarNo(carObj);

            if (result == null)
                return NotFound("Car doesn't exist in databse");

            //return Ok(result);
            return Ok(result.Select(c => _mapper.Map<CarVM>(c)));

        }

        [HttpDelete]
        [Route("{Car_No}")]
        public async Task<ActionResult<List<CarVM>>> DeleteCarByCarNo(string Car_No)
        {
            //calling the DeleteCarByCarNo from service
            var result = await _carService.DeleteCarByCarNo(Car_No);

            if (result == null) 
                return NotFound("Car doesn't exist in databse");

            //return Ok(result);
            return Ok(result.Select(c => _mapper.Map<CarVM>(c)));



        }
        
        [HttpGet]
        [Route("forBooking/{Car_No}")]//telling swagger for getting the car_no from user
        public async Task<ActionResult<int>> GetCarIDByCarNo(string Car_No)
        {
            var result = await _carService.GetCarIDByCarNo(Car_No);//forBooking = car_No from frontend

            if (result == 0)
                return NotFound("Car doesn't exist in databse");

            return Ok(result);
        }
    }

    
}
