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
        Task<ResponseModel<Payment>> NewPayment(IServiceProvider services);
        Task<bool> AddPayment(Payment payment);
        Task<bool> RemovePayment(int paymentId, int profileNumber);
        Task<ResponseModel<List<Payment>>> GetPayments(string cartId);
        Task<bool> ClearPayments(string cartId);

    }
}
