using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string CartId { get; set; }
        public int ProfileNumber { get; set; }
        public Funeral Funeral { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
    }
}
