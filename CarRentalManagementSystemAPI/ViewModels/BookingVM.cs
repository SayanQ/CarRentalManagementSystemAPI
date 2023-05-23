using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.ViewModels
{
    public class BookingVM
    {
        [Required]
        public int CarId { get; set; } = 0;

        public int? DriverId { get; set; }
        [Required]
        public int CustomerId { get; set; } = 0;

        [Required]
        public DateTime Booking_Date_Time { get; set; } = DateTime.Now;

        [Required]
        public DateTime Rental_Start_Date_Time { get; set; }

        [Required]
        public DateTime Rental_End_Date_Time { get; set; }

        [Required]
        public string Pick_Up_Location { get; set; } = string.Empty;

        [Required]
        public string Drop_Off_Location { get; set; } = string.Empty;
    }
}
