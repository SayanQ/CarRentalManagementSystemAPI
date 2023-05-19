using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;


namespace CarRentalManagementSystemAPI.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        public string Booking_Id { get; set; }
        public string Customer_Id { get; set; }
        public string Car_No { get; set; }

        public string? Driver_Id { get; set; }

        public string Payment_Type { get; set;}

        public bool Payment_Status { get; set; }

        public DateAndTime Payment_Date_Time { get; set; }
        public float Amount { get; set; }

        


    }
}
