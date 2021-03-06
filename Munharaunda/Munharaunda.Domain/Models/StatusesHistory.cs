﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Munharaunda.Domain.Models
{
    public class StatusesHistory
    {
        [Key]
        public int StatusHistoryId { get; set; }

        [ForeignKey("Statuses")]
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
        public int Status { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime Updated { get; set; }

        public DateTime Approve1 { get; set; }

        public int Approver1 { get; set; }

        public DateTime Approve2 { get; set; }

        public int Approver2 { get; set; }

        public DateTime Approve3 { get; set; }

        public int Approver3 { get; set; }

        public DateTime Approve4 { get; set; }

        public int Approver4 { get; set; }
    }
}
