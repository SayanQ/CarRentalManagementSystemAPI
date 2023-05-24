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
        public async Task<List<PaymentVM>> AddPayment(PaymentVM payment)
        {

            var _payment = new Payment()
            {
                BookingId = payment.BookingId,
            };


            await _context.AddAsync(_payment);
            await _context.SaveChangesAsync();

            return await GetAllPayments();
        }

        public async Task<List<PaymentVM>?> DeletePaymentByBookingId(int id)
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

        public async Task<List<PaymentVM>> GetAllPayments()
        {
            var payments = await _context.Payments.ToListAsync();

            List<PaymentVM> result = new List<PaymentVM>();

            foreach (var payment in payments)
            {
                var obj = new PaymentVM()
                {
                    BookingId = payment.BookingId,
                    Payment_Type = payment.Payment_Type,
                    Payment_Status = payment.Payment_Status,
                    Payment_Date_Time = payment.Payment_Date_Time,
                    Amount = payment.Amount
                };

                result.Add(obj);


            }
            return result;
        }

        public async Task<List<PaymentVM>?> GetPaymentsByType(string str)
        {
            var payments = await _context.Payments.Where(p => p.Payment_Type == str).ToListAsync();
            var result = new List<PaymentVM>();
            PaymentVM paymentVM;

            if (payments == null)
            {
                return null;
            }
            else
            {
                foreach (var payment in payments)
                {
                    paymentVM = new PaymentVM()
                    {
                        BookingId = payment.BookingId,
                        Payment_Type = payment.Payment_Type,
                        Payment_Status = payment.Payment_Status,
                        Payment_Date_Time = payment.Payment_Date_Time,
                        Amount = payment.Amount
                    };
                    result.Add(paymentVM);
                }

            }

            return result;
        }
        public async Task<List<PaymentVM>?> GetPaymentsByStatus(bool b)
        {
            var payments = await _context.Payments.Where(p => p.Payment_Status == b).ToListAsync();
            var result = new List<PaymentVM>();
            PaymentVM paymentVM;

            if (payments == null)
            {
                return null;
            }
            else
            {
                foreach (var payment in payments)
                {
                    paymentVM = new PaymentVM()
                    {
                        BookingId = payment.BookingId,
                        Payment_Type = payment.Payment_Type,
                        Payment_Status = payment.Payment_Status,
                        Payment_Date_Time = payment.Payment_Date_Time,
                        Amount = payment.Amount
                    };
                    result.Add(paymentVM);
                }

            }

            return result;
        }
        public async Task<List<Payment>?> UpdatePaymentBookingId(PaymentVM payment)
        {
            var findPayment = await _context.Payments.FirstOrDefaultAsync(b => b.BookingId == id);

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
