using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<CustomerVM>> GetAllCustomers();
        Task<List<CustomerVM>> AddCustomer(CustomerVM customer);
        Task<List<CustomerVM>?> GetCustomersByName(string name);
        Task<CustomerVM?> GetCustomerByPhoneNoOrEmailOrAadharOrPan(string str);
        Task<List<CustomerVM>?> UpdateCustomer(CustomerVM customer);
        Task<List<CustomerVM>?> DeleteCustomer(string phone);
    }
}
