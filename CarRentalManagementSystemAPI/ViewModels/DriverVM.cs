using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.ViewModels
{
    public class DriverVM
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
        public string Adhaar_no { get; set; } 
        [Required]
        [StringLength(12, MinimumLength = 12)]
        [RegularExpression(@"^[A-Z]{5}-\d{4}-[A-Z]{1}$", ErrorMessage = "Pan number must be in the format ABCDE-1234-F")]
        public string Pan_No { get; set; } 
        [Required]
        public DateTime Date_Of_Birth { get; set; } 
        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{11}$", ErrorMessage = "Driving Licence must be in the correct form")]
        public string Driving_Licence_No { get; set; } 
        [Required]
        public DateTime Driving_Licence_Valid_Till { get; set; } 
        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "Driver must have complete 100 hours of driving.")]
        public int Km_Driven { get; set; } 
        [Required]
        [Range(100, 250, ErrorMessage = "Driver's per hour charge must be between 100 and 250.")]
        public float Charges_Per_Hour { get; set; } 
    }
}
