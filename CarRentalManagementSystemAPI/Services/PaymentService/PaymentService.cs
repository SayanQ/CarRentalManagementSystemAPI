namespace CarRentalManagementSystemAPI.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;

        public PaymentService(DataContext context) { 
            _context = context;
        }
        public async Task<List<Payment>> AddPayment(Payment payment)
        {
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();

            return await GetAllPayments();
        }

        public async Task<List<Payment>?> DeletePaymentBYId(Guid Id)
        {
            var findPayment = await _context.Payments.FindAsync(Id);
            if (findPayment == null)
            {
                return null;
            }

            _context.Payments.Remove(findPayment);
            await _context.SaveChangesAsync();

            return await GetAllPayments();
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment?> GetPaymentBYId(Guid Id)
        {
            var findPayment = await _context.Payments.FindAsync(Id);
            if(findPayment == null)
            {
                return null;
            }
            return findPayment;
        }

        public async Task<List<Payment>?> UpdatePaymentBYId(Payment payment)
        {
            var findPayment = await _context.Payments.FindAsync(payment.Id);
            if (findPayment == null)
            {
                return null;
            }

            findPayment.Id = payment.Id;
            findPayment.B_Id = payment.B_Id;
            findPayment.Payment_Type = payment.Payment_Type;    
            findPayment.Payment_Status = payment.Payment_Status;
            findPayment.Payment_Date_Time = payment.Payment_Date_Time;
            findPayment.Amount = payment.Amount;    


            await _context.SaveChangesAsync();


            return await GetAllPayments();
        }
    }
}
