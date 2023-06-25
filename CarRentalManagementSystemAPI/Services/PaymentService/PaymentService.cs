using CarRentalManagementSystemAPI.Models;
using CarRentalManagementSystemAPI.ViewModels;

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

        public async Task<List<Payment>?> DeletePaymentByBookingId(int id)
        {
            var findPayment = await _context.Payments.FirstOrDefaultAsync(b => b.BookingId == id);
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
            var payments = await _context.Payments.ToListAsync();
            return payments;
        }

        public async Task<List<Payment>?> GetPaymentsByType(string str)
        {
            var payments = await _context.Payments.Where(p => p.Payment_Type == str).ToListAsync();
            if (payments == null)
            {
                return null;
            }

            return payments;
        }
        public async Task<List<Payment>?> GetPaymentsByStatus(string b)//error
        {
            var payments = await _context.Payments.Where(p => p.Payment_Status == b).ToListAsync();
            return payments;
        }
        public async Task<List<Payment>?> UpdatePaymentByBookingId(Payment payment)
        {
            var findPayment = await _context.Payments.FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);

            if (findPayment == null)
            {
                return null;
            }
            findPayment.Payment_Type = payment.Payment_Type;
            findPayment.Payment_Status = payment.Payment_Status;
            findPayment.Payment_Date_Time = payment.Payment_Date_Time;
            findPayment.Amount = payment.Amount;

            await _context.SaveChangesAsync();
            return await GetAllPayments();
        }

    }
}
