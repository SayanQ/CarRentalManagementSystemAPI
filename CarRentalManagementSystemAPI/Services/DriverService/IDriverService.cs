namespace CarRentalManagementSystemAPI.Services.DriverService
{
    public interface IDriverService
    {
        Task<List<DriverVM>?> GetAllDrivers();
        Task<List<DriverVM>?> AddDriver(DriverVM driver);
        Task<List<DriverVM>?> DeleteDriver(string str);
        Task<List<DriverVM>?> GetDriversByName(string name);
        Task<DriverVM?> GetDriverByPhoneNoOrEmailOrAaddhaarOrPanOrDrivingLicence(string phoneNo);
        Task<List<DriverVM>?> UpdateDriver(DriverVM div);

    }
}
