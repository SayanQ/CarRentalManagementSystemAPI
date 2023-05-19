using System.Numerics;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace CarRentalManagementSystemAPI.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be in the format xxxxxxxxxx")]
        public string Phone { get; set; } =  string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(14, MinimumLength = 14)]
        [RegularExpression(@"^\d{4}-\d{4}-\d{4}$", ErrorMessage = "AAdhaar number must be in the format xxxx-xxxx-xxxx")]
        public string Aadhaar_no { get; set; } = string.Empty;

        [Required]
        [StringLength(12, MinimumLength = 12)]
        [RegularExpression(@"^[A-Z]{5}-[0-9]{4}-[A-Z]{1}$", ErrorMessage = "PAN number must be in the format ABCDE-1234-F")]

        public string Pan_No { get; set; } = string.Empty;

        [Required]
        public DateTime Date_Of_Birth { get; set; } = new DateTime();

    }
}
