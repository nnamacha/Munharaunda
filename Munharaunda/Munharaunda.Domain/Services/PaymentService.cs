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
        private readonly IServiceProvider _service;

        public string SessionId { get; set; }

        public PaymentService(IMunharaundaRepository dbRepo, IServiceProvider service)
        {
            _dbRepo = dbRepo;
            _service = service;
        }
        public async Task<ResponseModel<Payment>> AddPayment(Payment payment)
        {
            var response = new ResponseModel<Payment>()
            {
                ResponseData = new List<Payment>()
            };

            if (await _dbRepo.AddPayment(payment))
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData.Add(payment);
                return response;
            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R05;
                response.ResponseMessage = ReturnCodesConstant.R05Message;
                response.ResponseData.Add(payment);
                return response;
            }
               

        }

        public async Task<ResponseModel<string>> ClearPayments(string cartId)
        {
            var response = new ResponseModel<string>()
            {
                ResponseData = new List<string>(),
                Errors = new List<string>()
            };

            if (String.IsNullOrEmpty(cartId) || String.IsNullOrWhiteSpace(cartId))
            {
                response.ResponseCode = ReturnCodesConstant.R02;
                response.ResponseMessage = ReturnCodesConstant.R02Message;
                response.Errors.Add(ReturnCodesConstant.CARTID_IS_NULL);
                return response;
            }

            if (await _dbRepo.ClearPayments(cartId))
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                return response;

            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R05;
                response.ResponseMessage = ReturnCodesConstant.R05Message;
                return response;
            }
        }

        public async Task<ResponseModel<Payment>> GetPayments(string cartId)
        {
            var response = new ResponseModel<Payment>()
            {
                ResponseData = new List<Payment>(),
                Errors= new List<string>()
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

        public async Task<ResponseModel<Payment>> NewPayment(Payment payment)
        {
            ResponseModel<Payment> response = new ResponseModel<Payment>()
            {
                ResponseData = new List<Payment>(),
                Errors = new List<string>()
            };

            if (payment == null)
            {
                response.ResponseCode = ReturnCodesConstant.R08;
                response.ResponseMessage = ReturnCodesConstant.R08Message;
                response.Errors.Add("No payment record provided.");
                return response;
            };
           
            ISession session = _service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            string sessionId = session.GetString(SessionId) ?? Guid.NewGuid().ToString();
            session.SetString("SessionId", sessionId);

            payment.CartId = sessionId;

            

            if (await _dbRepo.NewPayment(payment))
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.R00Message;
                response.ResponseData.Add(payment);
                return response;

            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R05;
                response.ResponseMessage = ReturnCodesConstant.R05Message;
                response.Errors.Add(ReturnCodesConstant.CREATE_NEW_PAYMENT_FAILED);
                return response;
            }
                
        }

        public async Task<ResponseModel<string>> RemovePayment(int paymentId)
        {
            ResponseModel<string> response = new ResponseModel<string>()
            {
                ResponseData = new List<string>()
            };

            if (await _dbRepo.RemovePayment(paymentId))
            {
                response.ResponseCode = ReturnCodesConstant.R00;
                response.ResponseMessage = ReturnCodesConstant.PAYMENT_RECORD_REMOVED_SUCCESSFULLY;
                return response;
            }
            else
            {
                response.ResponseCode = ReturnCodesConstant.R05;
                response.ResponseMessage = ReturnCodesConstant.R05Message;
                return response;

            }
           
        }
    }
}
