using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Munharaunda.Domain.Models
{
    public class TransactionCodesHistory
    {
        [Key]
        public int TransactionCodeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Credit { get; set; }
        [Required]
        public bool Contribution { get; set; }

        public int Status { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime Updated { get; set; }
    }
}
