namespace CarRentalManagementSystemAPI.Services.CarService
{
    public interface ICarService
    {
        Task<List<CarVM>> GetAllCars();
        Task<CarVM?> GetCarByCarNo(string Car_No);
        Task<List<CarVM>?> GetCarsByModel(string model);
        Task<List<CarVM>> AddCar(CarVM car);
        Task<List<CarVM>?> UpdateCarByCarNo(CarVM car);
        Task<List<CarVM>?> DeleteCarByCarNo(string Car_No);
    }
}
