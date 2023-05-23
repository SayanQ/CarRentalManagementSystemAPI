using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.ViewModels
{
    public class CarVM
    {
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{2}[A-Z]{2}\d{4}$", ErrorMessage = "Car number must be in the format AB12CD3456")]
        public string Car_No { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Company { get; set; } = string.Empty;
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Type { get; set; } = string.Empty;
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Colour { get; set; } = string.Empty;
        [Required]
        public int Year_Of_Manufacturing { get; set; } = int.MinValue;
        [Required]
        public int Km_Driven { get; set; } = int.MinValue;
        [Required]
        public int Sitting_Capacity { get; set; } = int.MinValue;
        [Required]
        public int Boot_space { get; set; } = int.MinValue;
        [Required]
        public float Charges_Per_Hour { get; set; } = float.MinValue;
    }

  
}
