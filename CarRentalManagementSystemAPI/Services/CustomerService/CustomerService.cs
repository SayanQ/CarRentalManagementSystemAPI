using CarRentalManagementSystemAPI.Models;

namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>?> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }

        public async Task<List<Customer>?> DeleteCustomerByCustomerId(Guid Customer_Id)
        {
            var findCustomer = await _context.Customers.FindAsync(Customer_Id);

            //checking the car is in our database or not
            if (findCustomer == null)
                return null;

            _context.Customers.Remove(findCustomer);
            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public async Task<Customer?> GetCustomerByCustomerId(Guid Customer_Id)
        {
            var findCustomer = await _context.Customers.FindAsync(Customer_Id);

            //checking the car is in our database or not
            if (findCustomer == null)
                return null;

            return findCustomer;
        }

        public async Task<List<Customer>?> UpdateCustomerByCustomerId(Customer customer)
        {
            var findCustomer = await _context.Customers.FindAsync(customer.Id);

            //checking the car is in our database or not
            if (findCustomer == null)
                return null;

            findCustomer.Id = customer.Id;
            findCustomer.Address = customer.Address;    
            findCustomer.Aadhaar_no = customer.Aadhaar_no;
            findCustomer.Phone = customer.Phone;
            findCustomer.Date_Of_Birth = customer.Date_Of_Birth;
            findCustomer.Email = customer.Email;
            findCustomer.Name = customer.Name;
            findCustomer.Pan_No = customer.Pan_No;  

            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }
    }
}
