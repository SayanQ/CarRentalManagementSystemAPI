namespace CarRentalManagementSystemAPI.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<List<Payment>> AddPayment(Payment payment);
        Task<List<Payment>?> DeletePaymentByBookingId(int id);
        Task<List<Payment>> GetAllPayments();
        Task<List<Payment>?> GetPaymentsByType(string str);
        Task<List<Payment>?> GetPaymentsByStatus(string b);
        Task<List<Payment>?> UpdatePaymentByBookingId(Payment payment);

    }
}
