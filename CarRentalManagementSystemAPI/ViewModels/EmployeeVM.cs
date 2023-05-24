using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.ViewModels
{
    public class EmployeeVM
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } 

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Address { get; set; } 

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be in the format xxxxxxxxxx")]
        public string Phone { get; set; } 

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } 

        [Required]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"^\d{4}-\d{4}-\d{4}$", ErrorMessage = "AAdhaar number must be in the format xxxx-xxxx-xxxx")]
        public string Aadhaar_no { get; set; } 

        [Required]
        [StringLength(12, MinimumLength = 12)]
        [RegularExpression(@"^[A-Z]{5}-[0-9]{4}-[A-Z]{1}$", ErrorMessage = "PAN number must be in the format ABCDE-1234-F")]

        public string Pan_No { get; set; }
        [Required]
        public DateTime Date_Of_Birth { get; set; } 
        [Required]
        public DateTime Hire_Date { get; set; } 
        [Required]
        [StringLength(20, MinimumLength = 2)]

        public string Job_Title { get; set; } 
        [Required]
        [StringLength(20, MinimumLength = 3)]

        public string Department { get; set; } 
        [Required]
        public bool Employee_Status { get; set; } 
        [Required]
        public long Annual_CTC { get; set; } 
    }
}
