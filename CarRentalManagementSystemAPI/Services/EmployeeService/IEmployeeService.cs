using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeVM>?> AddEmployee(EmployeeVM employee);
        Task<List<EmployeeVM>?> DeleteEmployee(string str);
        Task<List<EmployeeVM>> GetAllEmployees();
        Task<EmployeeVM?> GetEmployeeByPhoneNoOrEmailOrAadharOrPan(string str);
        Task<List<EmployeeVM>?> UpdateEmployee(EmployeeVM employee);


    }
}
