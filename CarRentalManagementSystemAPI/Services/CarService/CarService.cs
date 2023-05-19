//using CarRentalManagementSystemAPI.Models;
//using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Services.CarService
{
    public class CarService : ICarService
    {/*
        private static List<Car> cars = new List<Car> {
                new Car {
                    Car_No = "WB1022B1022",
                    Model = "ALTO",
                    Company = "Maruti",
                    Type = "HatchBack",
                    Colour = "Red",
                    Year_Of_Manufacturing = 2018,
                    Km_Driven = 100000,
                    Sitting_Capacity = 3,
                    Boot_space = 100,
                    Charges_Per_Hour = 30
                    },
                new Car {
                    Car_No = "WB1022C1022",
                    Model = "ALTO",
                    Company = "Maruti",
                    Type = "HatchBack",
                    Colour = "Black",
                    Year_Of_Manufacturing = 2018,
                    Km_Driven = 100000,
                    Sitting_Capacity = 3,
                    Boot_space = 100,
                    Charges_Per_Hour = 30
                    }
                };*/
        private readonly DataContext _context;

        public CarService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Car>?> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();//for saving the changes to the database the database

            return await GetAllCars();
        }

        public async Task<List<Car>?> DeleteCarByCarNo(string Car_No)
        {
            var findCar = await _context.Cars.FindAsync(Car_No);

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

        public async Task<Car?> GetCarByCarNo(string Car_No)
        {
            var findCar = await _context.Cars.FindAsync(Car_No);

            //checking the car is in our database or not
            if (findCar == null)
                return null;

            return findCar;
        }

        public async Task<List<Car>?> UpdateCarByCarNo(Car car)
        {
            var findCar = await _context.Cars.FindAsync(car.Car_No);

            //checking the car is in our database or not
            if (findCar == null)
                return null;

            findCar.Car_No = car.Car_No;
            findCar.Model = car.Model;
            findCar.Company = car.Company;
            findCar.Type = car.Type;
            findCar.Colour = car.Colour;
            findCar.Year_Of_Manufacturing = car.Year_Of_Manufacturing;
            findCar.Km_Driven = car.Km_Driven;
            findCar.Sitting_Capacity = car.Sitting_Capacity;
            findCar.Boot_space = car.Boot_space;

            await _context.SaveChangesAsync();//for saving the changes to the database

            return await GetAllCars();
        }
    }
}
 