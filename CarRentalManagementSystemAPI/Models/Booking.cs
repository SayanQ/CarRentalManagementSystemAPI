using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public string Customer_Id { get; set; }
        public string? Driver_Id { get; set; }
        public string Car_No { get; set; }
        public DateAndTime Booking_Date_Time { get; set; }
        public DateAndTime Rental_Start_Date_Time { get; set; }
        public DateAndTime Rental_End_Date_Time { get; set; }
        public string Pick_Up_Location { get; set; }
        public string Drop_Off_Location { get; set; }
    }
}
