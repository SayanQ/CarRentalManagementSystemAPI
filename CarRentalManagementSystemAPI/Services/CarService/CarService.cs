//using CarRentalManagementSystemAPI.Models;
//using Microsoft.AspNetCore.Mvc;

using CarRentalManagementSystemAPI.Models;
using System.Collections.Generic;
using System.Drawing;

namespace CarRentalManagementSystemAPI.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;

        public CarService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CarVM>> AddCar(CarVM car)
        {
            var _car = new Car()
            {
                Car_No = car.Car_No,
                Model = car.Model,
                Company = car.Company,
                Type = car.Type,
                Colour = car.Colour,
                Year_Of_Manufacturing = car.Year_Of_Manufacturing,
                Km_Driven = car.Km_Driven,
                Sitting_Capacity = car.Sitting_Capacity,
                Boot_space = car.Boot_space
            };
            _context.Cars.Add(_car);
            await _context.SaveChangesAsync();//for saving the changes to the database the database
            
            return await GetAllCars();
        }

        public async Task<List<CarVM>?> DeleteCarByCarNo(string Car_No)
        {
            var findCar = await _context.Cars.FirstOrDefaultAsync(c => c.Car_No == Car_No);

            //checking the car is in our database or not
            if (findCar == null)
                return null;
            
            _context.Cars.Remove(findCar);//deleteing the car from our database   
            await _context.SaveChangesAsync();//for updating the database

            return await GetAllCars();
        }

        public async Task<List<CarVM>> GetAllCars()
        {
            var cars = await _context.Cars.ToListAsync();

            List<CarVM> result = new List<CarVM>();

            foreach (var car in cars)
            {
                CarVM obj = new CarVM() 
                {
                    Car_No = car.Car_No,
                    Model = car.Model,
                    Company = car.Company,
                    Type = car.Type,
                    Colour = car.Colour,
                    Year_Of_Manufacturing = car.Year_Of_Manufacturing,
                    Km_Driven = car.Km_Driven,
                    Sitting_Capacity = car.Sitting_Capacity,
                    Boot_space = car.Boot_space
                };

            result.Add(obj);


            }
            return result;
        }

        public async Task<CarVM?> GetCarByCarNo(string car_No)
        {
            var findCar = await _context.Cars.FirstOrDefaultAsync(c => c.Car_No == car_No);
            CarVM result;
            //checking the car is in our database or not
            if (findCar == null)
                return null;
            else
            {
                result = new CarVM()
                {
                    Car_No = findCar.Car_No,
                    Model = findCar.Model,
                    Company = findCar.Company,
                    Type = findCar.Type,
                    Colour = findCar.Colour,
                    Year_Of_Manufacturing = findCar.Year_Of_Manufacturing,
                    Km_Driven = findCar.Km_Driven,
                    Sitting_Capacity = findCar.Sitting_Capacity,
                    Boot_space = findCar.Boot_space
                };
            }

            return result;
        }

        public async Task<List<CarVM>?> GetCarsByModel(string model)
        {
            var cars = await _context.Cars.Where(c => c.Model == model).ToListAsync();

            var result = new List<CarVM>();
            CarVM carVM;
            //checking the car is in our database or not
            if (cars == null)
                return null;
            else
            {
                foreach (var findCar in cars)
                {
                    carVM = new CarVM()
                    {
                        Car_No = findCar.Car_No,
                        Model = findCar.Model,
                        Company = findCar.Company,
                        Type = findCar.Type,
                        Colour = findCar.Colour,
                        Year_Of_Manufacturing = findCar.Year_Of_Manufacturing,
                        Km_Driven = findCar.Km_Driven,
                        Sitting_Capacity = findCar.Sitting_Capacity,
                        Boot_space = findCar.Boot_space
                    };
                    result.Add(carVM);
                }
                
            }
            return result;
        }
             
        public async Task<List<CarVM>?> UpdateCarByCarNo(CarVM car)
        {
            var findCar = await _context.Cars.FirstOrDefaultAsync(c => c.Car_No == car.Car_No);

            //checking the car is in our database or not
            if (findCar == null)
                return null;
            else
            {
                findCar.Model = car.Model;
                findCar.Company = car.Company;
                findCar.Type = car.Type;
                findCar.Colour = car.Colour;
                findCar.Year_Of_Manufacturing = car.Year_Of_Manufacturing;
                findCar.Km_Driven = car.Km_Driven;
                findCar.Sitting_Capacity = car.Sitting_Capacity;
                findCar.Boot_space = car.Boot_space;

                await _context.SaveChangesAsync();//for saving the changes to the database
            }
            return await GetAllCars();
        }
    }
}
 