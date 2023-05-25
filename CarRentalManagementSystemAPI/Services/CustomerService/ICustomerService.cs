using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> AddCustomer(Customer customer);
        Task<List<Customer>?> GetCustomersByName(string name);
        Task<Customer?> GetCustomerByPhoneNoOrEmailOrAadharOrPan(string str);
        Task<List<Customer>?> UpdateCustomer(Customer customer);
        Task<List<Customer>?> DeleteCustomer(string phone);
    }
}
