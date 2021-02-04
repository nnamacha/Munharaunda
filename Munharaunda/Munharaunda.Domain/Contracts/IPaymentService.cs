using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Contracts
{
    public interface IPaymentService
    {
        Payment NewPayment(IServiceProvider services);
        Task<bool> AddPayment(Payment payment);
        Task<bool> RemovePayment(int paymentId, int profileNumber);
        Task<List<Payment>> GetPayments();
        Task<bool> ClearPayments(string cartId);

    }
}
