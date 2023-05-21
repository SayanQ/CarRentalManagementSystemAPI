namespace CarRentalManagementSystemAPI.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment?> GetPaymentBYId(Guid Id);
        Task<List<Payment>?> DeletePaymentBYId(Guid Id);
        Task<List<Payment>?> UpdatePaymentBYId(Payment payment);
        Task<List<Payment>> AddPayment(Payment payment);

    }
}
