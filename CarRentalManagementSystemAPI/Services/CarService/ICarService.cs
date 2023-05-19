using CarRentalManagementSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagementSystemAPI.Services.CarService
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();
        Task<Car>? GetCarByCarNo(string Car_No);
        Task<List<Car>?> AddCar(Car car);
        Task<List<Car>?> UpdateCarByCarNo(Car car);
        Task<List<Car>?> DeleteCarByCarNo(string Car_No);
    }
}
