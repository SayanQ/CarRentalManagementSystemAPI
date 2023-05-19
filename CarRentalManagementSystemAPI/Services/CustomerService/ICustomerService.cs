using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerByCustomerId(Guid Customer_Id);
        Task<List<Customer>?> AddCustomer(Customer customer);
        Task<List<Customer>?> UpdateCustomerByCustomerId(Customer customer);
        Task<List<Customer>?> DeleteCustomerByCustomerId(Guid Customer_Id);
    }
}
