using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
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
            if (String.IsNullOrEmpty(cartId) || String.IsNullOrWhiteSpace(cartId))
            {
                return false;
            }

            return await _dbRepo.ClearPayments(cartId);
        }

        public async Task<ResponseModel<List<Payment>>> GetPayments(string cartId)
        {
            var response = new ResponseModel<List<Payment>>()
            {
                ResponseData = new List<Payment>()
            };

            if (String.IsNullOrEmpty(cartId) || String.IsNullOrWhiteSpace(cartId))
            {
                response.ResponseCode = ReturnCodesConstant.R08;
                response.ResponseMessage = ReturnCodesConstant.R08Message;
                response.Errors.Add("No CartId provided.");
                return response;
            };

            var dbResponse =  await _dbRepo.GetPayments(cartId);

            if (dbResponse.Count == 0)
            {
                response.ResponseCode = ReturnCodesConstant.R06;
                response.ResponseMessage = ReturnCodesConstant.R06Message;
                return response;
            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData = dbResponse;
                return response;
            }

        }

        public async Task<ResponseModel<Payment>> NewPayment(IServiceProvider services)
        {
            ResponseModel<Payment> response = new ResponseModel<Payment>();
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            string sessionId = session.GetString(SessionId) ?? Guid.NewGuid().ToString();
            session.SetString("SessionId", sessionId);
            var dbResponse = await _dbRepo.NewPayment(sessionId);

            if (dbResponse != null)
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData = dbResponse;
                return response;

            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R01;
                response.ResponseMessage = ReturnCodesConstant.R01Message;
                response.Errors.Add(ReturnCodesConstant.CREATE_NEW_PAYMENT_FAILED);
                return response;
            }
                
        }

        public async Task<bool> RemovePayment(int paymentId, int profileNumber)
        {
            throw new NotImplementedException();
        }
    }
}
