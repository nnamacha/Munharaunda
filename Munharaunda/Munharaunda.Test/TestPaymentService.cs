using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using Munharaunda.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Munharaunda.Test
{
    public class TestPaymentService
    {
        private readonly IMunharaundaRepository _dbRepo;
        private readonly Mock<IMunharaundaRepository> _mockDbRepo;
        private readonly PaymentService _paymentService;
        private Funeral funeralRec;
        private Payment addPaymentRequest;
        private readonly List<Payment> paymentListWithRecord;
        private readonly List<Payment> emptyPaymentList;
        private readonly Mock<IServiceProvider> _mockService;
        private readonly IServiceProvider _services;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;

        public TestPaymentService()
        {
            
            _mockDbRepo = new Mock<IMunharaundaRepository>();
            _mockService = new Mock<IServiceProvider>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            _paymentService = new PaymentService(_mockDbRepo.Object, _mockService.Object);
            funeralRec = new Funeral()
            {
                FuneralId = 1,
                DeceasedsProfileNumber = 5,
                AddressForFuneral = "15 Albany Crescent Warren Park",
                StatusId = 5,
                Created = new DateTime(2021, 1, 1),
                CreatedBy = 1,
                Comment = "Test Funeral"
            };
            addPaymentRequest = new Payment()
            {
                CartId = "4547124",
                ProfileNumber = 1,
                Funeral = funeralRec,
                Amount = 100.00M,
                PaymentId = 1,
                TransactionId = 1


            };

            paymentListWithRecord = new List<Payment>();
            paymentListWithRecord.Add(addPaymentRequest);
            emptyPaymentList = new List<Payment>();
            _mockDbRepo.Setup(x => x.AddPayment(It.IsAny<Payment>())).ReturnsAsync(true);
            
        }
        

        [Theory]
        [InlineData(true, ReturnCodesConstant.R00)]
        [InlineData(false, ReturnCodesConstant.R05)]

        public async void TestAddPayment(bool dbResponse , string responseCode)
        {
            _mockDbRepo.Setup(x => x.AddPayment(It.IsAny<Payment>())).ReturnsAsync(dbResponse);
            var response = await _paymentService.AddPayment(addPaymentRequest);

            Assert.Equal(responseCode, response.ResponseCode);

        }
        [Fact]
        public async void TestNullCartIdClearPayments()
        {
            _mockDbRepo.Setup(x => x.AddPayment(It.IsAny<Payment>())).ReturnsAsync(true);
            var response = await _paymentService.ClearPayments("");
            Assert.Equal(ReturnCodesConstant.R02, response.ResponseCode);
        }
        [Theory]
        [InlineData(true, ReturnCodesConstant.R00)]
        [InlineData(false, ReturnCodesConstant.R05)]
        public async void TestClearPayments(bool dbResponse, string responseCode)
        {
            _mockDbRepo.Setup(x => x.ClearPayments(It.IsAny<string>())).ReturnsAsync(dbResponse);
            var response = await _paymentService.ClearPayments("123");

            Assert.Equal(responseCode, response.ResponseCode);
        }

        [Fact]
        public async void TestNullCartIdGetPayments()
        {
           // _mockDbRepo.Setup(x => x.AddPayment(It.IsAny<Payment>())).ReturnsAsync(true);
            var response = await _paymentService.GetPayments("");
            Assert.Equal(ReturnCodesConstant.R08, response.ResponseCode);
        }
        [Theory]
        [InlineData(ReturnCodesConstant.R00)]
        [InlineData(ReturnCodesConstant.R06)]
        public async void TestGetPayment(string responseCode)
        {
            List<Payment> dbResponse = new List<Payment>();
            if (responseCode == ReturnCodesConstant.R00)
            {
                dbResponse = paymentListWithRecord;
            }
            _mockDbRepo.Setup(x => x.GetPayments(It.IsAny<string>())).ReturnsAsync(dbResponse);
            var response = await _paymentService.GetPayments("123");

            Assert.Equal(responseCode, response.ResponseCode);
        }

        [Fact]
        public async void TestNullpaymentNewPayment()
        {
            addPaymentRequest = null;
            var context = new DefaultHttpContext();

            _mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(context);
            var response = await _paymentService.NewPayment(addPaymentRequest);
            Assert.Equal(ReturnCodesConstant.R08, response.ResponseCode);
        }


    }
}
