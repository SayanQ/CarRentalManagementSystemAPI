using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee>? GetEmployeeByEmployeeId(Guid id);
        Task<List<Employee>?> AddEmployee(Employee employee);
        Task<List<Employee>?> UpdateEmployeeByEmployeeId(Employee employee);
        Task<List<Employee>?> DeleteEmployeeByEmployeeId(Guid id);
    }
}
