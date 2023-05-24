namespace CarRentalManagementSystemAPI.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<List<PaymentVM>> AddPayment(PaymentVM payment);
        Task<List<PaymentVM>?> DeletePaymentByBookingId(int id);
        Task<List<PaymentVM>> GetAllPayments();
        Task<List<PaymentVM>?> GetPaymentsByType(string str);
        Task<List<PaymentVM>?> GetPaymentsByStatus(bool b);
        Task<List<Payment>?> UpdatePaymentBookingId(PaymentVM payment);

    }
}
