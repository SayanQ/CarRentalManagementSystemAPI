using System.ComponentModel.DataAnnotations;

namespace CarRentalManagementSystemAPI.ViewModels
{
    public class PaymentVM
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        [RegularExpression(@"^(card|cash|upi)$", ErrorMessage = "Payment method should be within card, cash or upi")]

        public string Payment_Type { get; set; }

        [Required]
        //[RegularExpression(@"^(1|0)$", ErrorMessage = "Payment status should be within true or false")]

        public int Payment_Status { get; set; }


        [Required]
        public DateTime Payment_Date_Time { get; set; }

        [Required]
        public float Amount { get; set; }
    }
}
