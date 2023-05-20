using CarRentalManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

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

            return await GetAllDrivers(); ;
        }

        public async Task<List<Driver>?> DeleteDriverByDriverId(Guid id)
        {
            var findDriver = _context.Drivers.Find(id);
            if (findDriver == null)
                return null;

            _context.Drivers.Remove(findDriver);
            await _context.SaveChangesAsync();

            return await GetAllDrivers() ;
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver?> GetDriverByDriverId(Guid id)
        {
            var findDriver = _context.Drivers.Find(id);
            
            if (findDriver == null)
                return null;

            return findDriver;
        }

        public async Task<List<Driver>?> UpdateDriverByDriverId(Driver driver)
        {
            var findDriver = _context.Drivers.Find(driver.Id);
            if (findDriver == null)
                return null;

            _context.Drivers.Remove(findDriver);

            findDriver.Id = driver.Id;
            findDriver.Name = driver.Name;
            findDriver.Address = driver.Address;
            findDriver.Adhaar_no = driver.Adhaar_no;
            findDriver.Pan_No = driver.Pan_No;
            findDriver.Phone = driver.Phone;
            findDriver.Date_Of_Birth = driver.Date_Of_Birth;
            findDriver.Charges_Per_Hour = driver.Charges_Per_Hour;
            findDriver.Driving_Licence_No = driver.Driving_Licence_No;
            findDriver.Driving_Licence_Valid_Till = driver.Driving_Licence_Valid_Till;
            findDriver.Km_Driven = driver.Km_Driven;    


            await _context.SaveChangesAsync();

            return await GetAllDrivers();
        }
    }
}
