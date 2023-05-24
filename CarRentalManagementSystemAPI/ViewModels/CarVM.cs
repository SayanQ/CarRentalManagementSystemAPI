using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.ViewModels
{
    public class CarVM
    {
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{2}[A-Z]{2}\d{4}$", ErrorMessage = "Car number must be in the format AB12CD3456")]
        public string Car_No { get; set; } 
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Model { get; set; } 
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Company { get; set; } 
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Type { get; set; } 
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Colour { get; set; } 
        [Required]
        public int Year_Of_Manufacturing { get; set; } 
        [Required]
        public int Km_Driven { get; set; } 
        [Required]
        public int Sitting_Capacity { get; set; } 
        [Required]
        public int Boot_space { get; set; } 
        [Required]
        public float Charges_Per_Hour { get; set; } 
    }

  
}
