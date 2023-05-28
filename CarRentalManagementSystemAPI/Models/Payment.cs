using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        //[RegularExpression(@"^P_ID\d{4}$", ErrorMessage = "Customer Id must be in the format P_IDXXXX")]

        //public string Id { get; set; } = String.Empty;
        [Required]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        [Required]
        [RegularExpression(@"^(card|cash|upi)$", ErrorMessage = "Payment method should be within card, cash or upi")]
        public string Payment_Type { get; set;}

        [Required]
        //[RegularExpression(@"^(1|0)$", ErrorMessage = "Payment status should be within true or false")]
        [RegularExpression(@"^Pending|Complete$", ErrorMessage = "Payment status should be within completed or pending")]
        public string Payment_Status { get; set; }


        [Required]
        public DateTime Payment_Date_Time { get; set; }

        [Required]
        public float Amount { get; set; }
        /*
        public Payment()
        {
            Payment_Date_Time = DateTime.Now;
        }
        */

    }
}
