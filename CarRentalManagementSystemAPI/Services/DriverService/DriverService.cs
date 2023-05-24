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
        public async Task<List<DriverVM>?> AddDriver(DriverVM driver)
        {

            var _driver = new Driver()
            {
                Name = driver.Name,
                Address = driver.Address,
                Phone = driver.Phone,
                Email = driver.Email,
                Adhaar_no = driver.Adhaar_no,
                Pan_No = driver.Pan_No,
                Date_Of_Birth = driver.Date_Of_Birth,
                Driving_Licence_No = driver.Driving_Licence_No,
                Driving_Licence_Valid_Till = driver.Driving_Licence_Valid_Till,
                Km_Driven = driver.Km_Driven,
                Charges_Per_Hour = driver.Charges_Per_Hour
            };

            _context.Drivers.Add(_driver);
            await _context.SaveChangesAsync();

            return await GetAllDrivers(); ;
        }
        public async Task<List<DriverVM>?> GetAllDrivers()
        {
            var drivers = await _context.Drivers.ToListAsync();

            List<DriverVM> result = new List<DriverVM>();

            foreach (var driver in drivers)
            {
                var obj = new DriverVM()
                {
                    Name = driver.Name,
                    Address = driver.Address,
                    Phone = driver.Phone,
                    Email = driver.Email,
                    Adhaar_no = driver.Adhaar_no,
                    Pan_No = driver.Pan_No,
                    Date_Of_Birth = driver.Date_Of_Birth,
                    Driving_Licence_No = driver.Driving_Licence_No,
                    Driving_Licence_Valid_Till = driver.Driving_Licence_Valid_Till,
                    Km_Driven = driver.Km_Driven,
                    Charges_Per_Hour = driver.Charges_Per_Hour
                };

                result.Add(obj);


            }
            return result;
        }
        public async Task<List<DriverVM>?> DeleteDriver(string str)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Phone == str || d.Email == str || d.Adhaar_no == str || d.Pan_No == str || d.Driving_Licence_No == str);


            //checking the car is in our database or not
            if (driver == null)
                return null;

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return await GetAllDrivers();
        }
        public async Task<List<DriverVM>?> GetDriversByName(string name)
        {
            var drivers = await _context.Drivers.Where(d => d.Name == name).ToListAsync();

            var result = new List<DriverVM>();

            DriverVM driverVM;

            if (drivers == null)
                return null;
            else
            {
                foreach (var driver in drivers)
                {
                    driverVM = new DriverVM()
                    {
                        Name = driver.Name,
                        Address = driver.Address,
                        Phone = driver.Phone,
                        Email = driver.Email,
                        Adhaar_no = driver.Adhaar_no,
                        Pan_No = driver.Pan_No,
                        Date_Of_Birth = driver.Date_Of_Birth,
                        Driving_Licence_No = driver.Driving_Licence_No,
                        Driving_Licence_Valid_Till = driver.Driving_Licence_Valid_Till,
                        Km_Driven = driver.Km_Driven,
                        Charges_Per_Hour = driver.Charges_Per_Hour
                    };
                    result.Add(driverVM);
                }

            }
            return result;

        }
        public async Task<DriverVM?> GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(string str)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Phone == str || d.Email == str || d.Adhaar_no == str || d.Pan_No == str || d.Driving_Licence_No == str);
            DriverVM result;
            //checking the car is in our database or not
            if (driver == null)
                return null;
            else
            {
                result = new DriverVM()
                {
                    Name = driver.Name,
                    Address = driver.Address,
                    Phone = driver.Phone,
                    Email = driver.Email,
                    Adhaar_no = driver.Adhaar_no,
                    Pan_No = driver.Pan_No,
                    Date_Of_Birth = driver.Date_Of_Birth,
                    Driving_Licence_No = driver.Driving_Licence_No,
                    Driving_Licence_Valid_Till = driver.Driving_Licence_Valid_Till,
                    Km_Driven = driver.Km_Driven,
                    Charges_Per_Hour = driver.Charges_Per_Hour
                };
            }

            return result;
        }
        public async Task<List<DriverVM>?> UpdateDriver(DriverVM driver)
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
