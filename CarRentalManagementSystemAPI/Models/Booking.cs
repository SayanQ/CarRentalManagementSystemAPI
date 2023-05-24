using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Booking
    {
       
        [Key]
        public int Id { get; set; }

        //Navigation Property
        public int CarId { get; set; } 
        public Car Car { get; set; } 

        //Navigation Property

        public int? DriverId { get; set; }
        public Driver Driver { get; set; } 


        //Navigation Property

        public int CustomerId { get; set; } 
        public Customer Customer { get; set; } 



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
    }
}
