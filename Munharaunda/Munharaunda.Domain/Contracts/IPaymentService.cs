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
        Task<ResponseModel<Payment>> NewPayment(IServiceProvider services, Payment payment);
        Task<ResponseModel<Payment>> AddPayment(Payment payment);
        Task<ResponseModel<string>> RemovePayment(int paymentId);
        Task<ResponseModel<Payment>> GetPayments(string cartId);
        Task<ResponseModel<string>> ClearPayments(string cartId);

    }
}
