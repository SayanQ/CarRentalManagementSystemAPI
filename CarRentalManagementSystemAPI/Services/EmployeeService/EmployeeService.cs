using CarRentalManagementSystemAPI.Models;
using CarRentalManagementSystemAPI.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Numerics;

namespace CarRentalManagementSystemAPI.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        public EmployeeService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>?> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return await GetAllEmployees();
        }

        public async Task<List<Employee>?> DeleteEmployee(string str)
        {
            var findEmployee = await _context.Employees.FirstOrDefaultAsync(c => c.Phone == str || c.Email == str || c.Aadhaar_no == str || c.Pan_No == str);


            if (findEmployee == null)
                return null;

            _context.Employees.Remove(findEmployee);
            await _context.SaveChangesAsync();

            return await GetAllEmployees();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            return employees;
        }

        public async Task<Employee?> GetEmployeeByPhoneNoOrEmailOrAadharOrPan(string str)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(c => c.Phone == str || c.Email == str || c.Aadhaar_no == str || c.Pan_No == str);
                      
            if (employee == null)
                return null;
            
            return (employee);
        }

        public async Task<List<Employee>?> UpdateEmployee(Employee employee)
        {
            var employee1 = await _context.Employees.FirstOrDefaultAsync(c => c.Phone == employee.Phone);

            //checking the car is in our database or not
            if (employee1 == null)
                return null;
            else
            {
                employee1.Name = employee.Name;
                employee1.Address = employee.Address;
                employee1.Phone = employee.Phone;
                employee1.Email = employee.Email;
                employee1.Aadhaar_no = employee.Aadhaar_no;
                employee1.Pan_No = employee.Pan_No;
                employee1.Date_Of_Birth = employee.Date_Of_Birth;
                employee1.Hire_Date = employee.Hire_Date;
                employee1.Job_Title = employee.Job_Title;
                employee1.Employee_Status = employee.Employee_Status;
                employee1.Department = employee.Department;
                employee1.Annual_CTC = employee.Annual_CTC;

                await _context.SaveChangesAsync();//for saving the changes to the database
            }
            return await GetAllEmployees();
        }
    }
}
