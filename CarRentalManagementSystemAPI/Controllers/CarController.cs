using CarRentalManagementSystemAPI.Services.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        //Return all cars
        [HttpGet]//for sending response to the swagger 
        public async Task<ActionResult<List<CarVM>?>> GetAllCars()
        {
            return await _carService.GetAllCars();
        }

        //Return cars by car no
        [HttpGet]
        [Route("{Car_No}")]//telling swagger for getting the car_no from user
        public async Task<ActionResult<List<Car>>> GetCarByCarNo(string Car_No)
        {
            var result = await _carService.GetCarByCarNo(Car_No);

            if (result == null)
                return NotFound("Car doesn't exist in databse");

            return Ok(result);
        }

        [HttpGet("byModel/{model}")]
        //[Route("{Model}")]//telling swagger for getting the car_no from user
        public async Task<ActionResult<List<Car>>> GetCarByModel(string model)
        {
            var result = await _carService.GetCarsByModel(model);

            if (result == null)
                return NotFound("Car doesn't exist in databse");

            return Ok(result);
        }

        //Add car in the cars
        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(CarVM car)//telling the method that input will be getting from the body
        {
            var result = await _carService.AddCar(car);
            return Ok(result);
        }

        //Update cars by car no
        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCarByCarNo([FromBody]CarVM car)
        {
            var result = await _carService.UpdateCarByCarNo(car);

            if (result == null)
                return NotFound("Car doesn't exist in databse");

            return Ok(result);
        }

        [HttpDelete]
        [Route("{Car_No}")]
        public async Task<ActionResult<List<Car>>> DeleteCarByCarNo(string Car_No)
        {
            //calling the DeleteCarByCarNo from service
            var result = await _carService.DeleteCarByCarNo(Car_No);

            if (result == null) 
                return NotFound("Car doesn't exist in databse");

            return Ok(result);


        }
    }

    
}
