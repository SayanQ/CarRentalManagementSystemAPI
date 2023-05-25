namespace CarRentalManagementSystemAPI.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>?> AddEmployee(Employee employee);
        Task<List<Employee>?> DeleteEmployee(string str);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeByPhoneNoOrEmailOrAadharOrPan(string str);
        Task<List<Employee>?> UpdateEmployee(Employee employee);


    }
}
