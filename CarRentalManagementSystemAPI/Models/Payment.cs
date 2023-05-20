using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string B_Id { get; set; }
        public Booking Booking { get; set; }

        [Required]
        public string Payment_Type { get; set;}

        [Required]
        public bool Payment_Status { get; set; }


        [Required]
        public DateTime Payment_Date_Time { get; set; }

        [Required]
        public float Amount { get; set; }

        public Payment()
        {
            Payment_Date_Time = DateTime.Now;
        }


    }
}
