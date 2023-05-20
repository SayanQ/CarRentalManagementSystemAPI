using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }

        // Foreign key property referencing Customer table
        [Required]
        public Guid C_Id { get; set; }
        public Customer Customer { get; set; }
        // Foreign key property referencing Driver table
        public Guid? D_Id { get; set; }
        public Driver Driver { get; set; }
        [Required]
        // Foreign key property referencing Car table
        public string C_No { get; set; }
        public Car Car { get; set; }    
        [Required]

        public DateTime Booking_Date_Time { get; set; }
        [Required]

        public DateTime Rental_Start_Date_Time { get; set; }
        [Required]

        public DateTime Rental_End_Date_Time { get; set; }
        [Required]

        public string Pick_Up_Location { get; set; }
        [Required]

        public string Drop_Off_Location { get; set; }


        public Booking()
        {
            Booking_Date_Time = DateTime.Now;
        }
    }
}
