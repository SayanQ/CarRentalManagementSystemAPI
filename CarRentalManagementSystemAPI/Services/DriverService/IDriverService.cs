namespace CarRentalManagementSystemAPI.Services.DriverService
{
    public interface IDriverService
    {
        Task<List<Driver>?> GetAllDrivers();
        Task<List<Driver>?> AddDriver(Driver driver);
        Task<List<Driver>?> DeleteDriver(string str);
        Task<List<Driver>?> GetDriversByName(string name);
        Task<Driver?> GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(string phoneNo);
        Task<List<Driver>?> UpdateDriver(Driver div);
        Task<int?> GetDriverIDByPhoneNo(string phoneNo);

    }
}
