using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<CustomerVM>> GetAllCustomers();
        Task<List<CustomerVM>> AddCustomer(CustomerVM customer);
        Task<List<CustomerVM>?> GetCustomersByName(string name);
        Task<CustomerVM?> GetCustomerByPhoneNo(string phoneNo);
        Task<CustomerVM?> GetCustomerByEmailId(string email);
        Task<CustomerVM?> GetCustomerByAadhaarNo(string aadhaar);
        Task<CustomerVM?> GetCustomerByPanNo(string pan);
        Task<List<CustomerVM>?> UpdateCustomer(CustomerVM customer);
        Task<List<CustomerVM>?> DeleteCustomerByPhoneNo(string phone);
    }
}
