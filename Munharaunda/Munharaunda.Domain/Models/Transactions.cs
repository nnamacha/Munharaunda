using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Munharaunda.Domain.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        
        public int FuneralId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int TransactionCode { get; set; }

        
        public bool Contribution { get; set; }
        public string Comment { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int Status { get; set; }

        public DateTime Approve1 { get; set; }
        
        public int Approver1 { get; set; }

        public DateTime Approve2 { get; set; }
        
        public int Approver2 { get; set; }

        public DateTime Approve3 { get; set; }
        [Required]
        public int Approver3 { get; set; }

        public DateTime Approve4 { get; set; }
        [Required]
        public int Approver4 { get; set; }





    }
}
