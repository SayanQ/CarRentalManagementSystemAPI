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
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return await GetAllEmployees();
        }

        public async Task<List<Employee>?> DeleteEmployeeByEmployeeId(Guid id)
        {
            var findEmployee = await _context.Employees.FindAsync(id);

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

        public async Task<Employee>? GetEmployeeByEmployeeId(Guid id)
        {
            var findEmployee = await _context.Employees.FindAsync(id);

            if(findEmployee == null)
                return null;

            return findEmployee;
        }

        public async Task<List<Employee>?> UpdateEmployeeByEmployeeId(Employee employee)
        {
            var findEmployee = await _context.Employees.FindAsync(employee.Id);

            if (findEmployee == null)
                return null;

            findEmployee.Id = employee.Id;
            findEmployee.Address = employee.Address;
            findEmployee.Name = employee.Name;
            findEmployee.Phone = employee.Phone;    
            findEmployee.Date_Of_Birth = employee.Date_Of_Birth;
            findEmployee.Email = employee.Email;
            findEmployee.Aadhaar_no = employee.Aadhaar_no;
            findEmployee.Pan_No = employee.Pan_No;
            findEmployee.Department = employee.Department;
            findEmployee.Annual_CTC= employee.Annual_CTC;
            findEmployee.Hire_Date = employee.Hire_Date;
            findEmployee.Employee_Status = employee.Employee_Status;
            findEmployee.Job_Title = employee.Job_Title;    
          
            await _context.SaveChangesAsync();  


            return await GetAllEmployees();
        }
    }
}
