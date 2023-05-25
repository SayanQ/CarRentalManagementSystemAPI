namespace CarRentalManagementSystemAPI.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;

        public CarService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Car>> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();//for saving the changes to the database the database
            
            return await GetAllCars();
        }

        public async Task<List<Car>?> DeleteCarByCarNo(string Car_No)
        {
            var findCar = await _context.Cars.FirstOrDefaultAsync(c => c.Car_No == Car_No);

            //checking the car is in our database or not
            if (findCar == null)
                return null;
            
            _context.Cars.Remove(findCar);//deleteing the car from our database   
            await _context.SaveChangesAsync();//for updating the database

            return await GetAllCars();
        }

        public async Task<List<Car>> GetAllCars()
        {
            var cars = await _context.Cars.ToListAsync();
 
            return cars;
        }

        public async Task<Car?> GetCarByCarNo(string car_No)
        {
            var findCar = await _context.Cars.FirstOrDefaultAsync(c => c.Car_No == car_No);

            if (findCar == null)
                return null;

            return findCar;
        }

        public async Task<List<Car>?> GetCarsByModel(string model)
        {
            var cars = await _context.Cars.Where(c => c.Model == model).ToListAsync();

            if (cars == null)
                return null;
            
            return cars;
        }
             
        public async Task<List<Car>?> UpdateCarByCarNo(Car car)
        {
            var findCar = await _context.Cars.FirstOrDefaultAsync(c => c.Car_No == car.Car_No);

            //checking the car is in our database or not
            if (findCar == null)
                return null;
        
            findCar.Model = car.Model;
            findCar.Company = car.Company;
            findCar.Type = car.Type;
            findCar.Colour = car.Colour;
            findCar.Year_Of_Manufacturing = car.Year_Of_Manufacturing;
            findCar.Km_Driven = car.Km_Driven;
            findCar.Sitting_Capacity = car.Sitting_Capacity;
            findCar.Boot_space = car.Boot_space;
            findCar.Charges_Per_Hour = car.Charges_Per_Hour;

            await _context.SaveChangesAsync();//for saving the changes to the database
            
            return await GetAllCars();
        }
    }
}
 