using Microsoft.AspNetCore.Mvc;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.MVC.Components
{
    public class PaymentSummary :ViewComponent
    {
        private readonly IPaymentService _paymentService;

        public PaymentSummary(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var items = await _paymentService.GetPayments();
           
                return View(items);
            
        }
    }
}
