using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Booking
    {
        /*
        [Key]
        public int Id { get; set; }

        //[RegularExpression(@"^B_ID\d{4}$", ErrorMessage = "Customer Id must be in the format B_IDXXXX")]

        //public string Id { get; set; }= string.Empty;

        // Foreign key property referencing Customer table
        [Required]
        public string C_Id { get; set; }
        public Customer Customer { get; set; }
        // Foreign key property referencing Driver table
        public string? D_Id { get; set; }
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

        */
        [Key]
        public int Id { get; set; }

        //Navigation Property
        public int CarId { get; set; } = 0;
        public Car Car { get; set; } = new Car();

        //Navigation Property

        public int? DriverId { get; set; }
        public Driver Driver { get; set; } = new Driver();


        //Navigation Property

        public int CustomerId { get; set; } = 0;
        public Customer Customer { get; set; } = new Customer();



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
