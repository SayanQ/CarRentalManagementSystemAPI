namespace CarRentalManagementSystemAPI.Services.DriverService
{
    public interface IDriverService
    {
        Task<List<Driver>> GetAllDrivers();
        Task<Driver>? GetDriverByDriverId(Guid id);
        Task<List<Driver>?> AddDriver(Driver driver);
        Task<List<Driver>?> UpdateDriverByDriverId(Driver driver);
        Task<List<Driver>?> DeleteDriverByDriverId(Guid id);
    }
}
