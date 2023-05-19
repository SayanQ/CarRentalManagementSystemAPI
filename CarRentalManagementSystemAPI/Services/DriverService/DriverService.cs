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

        public Task<List<Driver>?> DeleteDriverByDriverId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Driver>> GetAllDrivers()
        {
            throw new NotImplementedException();
        }

        public Task<Driver>? GetDriverByDriverId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Driver>?> UpdateDriverByDriverId(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
