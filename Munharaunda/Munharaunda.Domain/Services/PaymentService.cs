using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMunharaundaRepository _dbRepo;

        public string SessionId { get; set; }

        public PaymentService(IMunharaundaRepository dbRepo)
        {
            _dbRepo = dbRepo;
        }
        public async Task<bool> AddPayment(Payment payment)
        {
            if (payment != null)
            {
                return await _dbRepo.AddPayment(payment);
            }
            else
                return false;
            
        }

        public async Task<bool> ClearPayments(string cartId)
        {
            if (String.IsNullOrEmpty(cartId) || String.IsNullOrWhiteSpace(cartId) )
            {
                return false;
            }

            return await _dbRepo.ClearPayments(cartId);
        }

        public async Task<List<Payment>> GetPayments()
        {
            throw new NotImplementedException();
        }

        public Payment NewPayment(IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemovePayment(int paymentId, int profileNumber)
        {
            throw new NotImplementedException();
        }
    }
}
