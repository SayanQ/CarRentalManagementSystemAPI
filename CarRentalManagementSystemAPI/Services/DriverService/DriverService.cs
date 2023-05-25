using CarRentalManagementSystemAPI.Models;
using CarRentalManagementSystemAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace CarRentalManagementSystemAPI.Services.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly DataContext _context;
        public DriverService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Driver>?> AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return await GetAllDrivers();
        }
        public async Task<List<Driver>?> GetAllDrivers()
        {
            var drivers = await _context.Drivers.ToListAsync();                      
            return drivers;
        }
        public async Task<List<Driver>?> DeleteDriver(string str)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Phone == str || d.Email == str || d.Adhaar_no == str || d.Pan_No == str || d.Driving_Licence_No == str);

            //checking the car is in our database or not
            if (driver == null)
                return null;

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return await GetAllDrivers();
        }
        public async Task<List<Driver>?> GetDriversByName(string name)
        {
            var drivers = await _context.Drivers.Where(d => d.Name == name).ToListAsync();            
            return drivers;

        }
        public async Task<Driver?> GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(string str)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Phone == str || d.Email == str || d.Adhaar_no == str || d.Pan_No == str || d.Driving_Licence_No == str);            
            return driver;
        }
        public async Task<List<Driver>?> UpdateDriver(Driver driver)
        {
            var div = await _context.Drivers.FirstOrDefaultAsync(d => d.Phone == driver.Phone);

            //checking the car is in our database or not
            if (div == null)
                return null;
            else
            {
                div.Name = driver.Name;
                div.Address = driver.Address;
                div.Phone = driver.Phone;
                div.Email = driver.Email;
                div.Adhaar_no = driver.Adhaar_no;
                div.Pan_No = driver.Pan_No;
                div.Date_Of_Birth = driver.Date_Of_Birth;
                div.Driving_Licence_No = driver.Driving_Licence_No;
                div.Driving_Licence_Valid_Till = driver.Driving_Licence_Valid_Till;
                div.Km_Driven = driver.Km_Driven;
                div.Charges_Per_Hour = driver.Charges_Per_Hour;

                await _context.SaveChangesAsync();//for saving the changes to the database
            }
            return await GetAllDrivers();
        }
    }
}
