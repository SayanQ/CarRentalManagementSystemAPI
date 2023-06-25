namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
        public async Task<List<Customer>?> DeleteCustomer(string str)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == str || c.Email == str || c.Aadhaar_no == str || c.Pan_No == str);

            if (customer == null)
                return null;
           
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }
             
        public async Task<List<Customer>?> GetCustomersByName(string name)
        {
            var customers = await _context.Customers.Where(c => c.Name == name).ToListAsync();

            if (customers == null)
                return null;
            
            return customers;

        }

        public async Task<Customer?> GetCustomerByPhoneNoOrEmailOrAadharOrPan(string str)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == str || c.Email == str || c.Aadhaar_no == str || c.Pan_No == str);
            return customer;
        }
        public async Task<List<Customer>?> UpdateCustomer(Customer cust)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == cust.Phone);

            if (customer == null)
                return null;
            else
            {
                customer.Name = cust.Name;
                customer.Address = cust.Address;
                customer.Phone = cust.Phone;
                customer.Email = cust.Email;
                customer.Aadhaar_no = cust.Aadhaar_no;
                customer.Pan_No = cust.Pan_No;
                customer.Date_Of_Birth = cust.Date_Of_Birth;

                await _context.SaveChangesAsync();//for saving the changes to the database
            }
            return await GetAllCustomers();
        }

        public async Task<int?> GetCustomerIDByPhoneNo(string phoneNo)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == phoneNo);
            return customer.Id;
        }
    }
}
