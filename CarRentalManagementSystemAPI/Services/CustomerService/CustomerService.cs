using CarRentalManagementSystemAPI.Models;
using CarRentalManagementSystemAPI.ViewModels;
using System.Net;
using System.Numerics;

namespace CarRentalManagementSystemAPI.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CustomerVM>> AddCustomer(CustomerVM customer)
        {
            var _customer = new Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                Aadhaar_no = customer.Aadhaar_no,
                Pan_No = customer.Pan_No,
                Date_Of_Birth = customer.Date_Of_Birth
            };
            _context.Customers.Add(_customer);
            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }

        public async Task<List<CustomerVM>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            List<CustomerVM> result = new List<CustomerVM>();

            foreach (var customer in customers)
            {
                CustomerVM obj = new CustomerVM()
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Aadhaar_no = customer.Aadhaar_no,
                    Pan_No = customer.Pan_No,
                    Date_Of_Birth = customer.Date_Of_Birth
                };

                result.Add(obj);
            }
            return result;
        }
        public async Task<List<CustomerVM>?> DeleteCustomer(string str)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == str || c.Email == str || c.Address == str || c.Pan_No == str);

            if (customer == null)
                return null;
           
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return await GetAllCustomers();
        }
             
        public async Task<List<CustomerVM>?> GetCustomersByName(string name)
        {
            var customers = await _context.Customers.Where(c => c.Name == name).ToListAsync();

            List<CustomerVM> result = new List<CustomerVM>();

            CustomerVM customerVM;

            if (customers == null)
                return null;
            else
            {
                foreach (var customer in customers)
                {
                    customerVM = new CustomerVM()
                    {
                        Name = customer.Name,
                        Address = customer.Address,
                        Phone = customer.Phone,
                        Email = customer.Email,
                        Aadhaar_no = customer.Aadhaar_no,
                        Pan_No = customer.Pan_No,
                        Date_Of_Birth = customer.Date_Of_Birth
                    };
                    result.Add(customerVM);
                }

            }
            return result;

        }

        public async Task<CustomerVM?> GetCustomerByPhoneNoOrEmailOrAadharOrPan(string str)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == str || c.Email == str || c.Address == str || c.Pan_No == str);
            CustomerVM result;
            //checking the car is in our database or not
            if (customer == null)
                return null;
            else
            {
                result = new CustomerVM()
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Aadhaar_no = customer.Aadhaar_no,
                    Pan_No = customer.Pan_No,
                    Date_Of_Birth = customer.Date_Of_Birth
                };
            }

            return result;
        }
        public async Task<List<CustomerVM>?> UpdateCustomer(CustomerVM cust)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Phone == cust.Phone);

            //checking the car is in our database or not
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

    }
}
