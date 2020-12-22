using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Munharaunda.Domain.Models
{
    public class Funeral
    {
        [Key]
        public int FuneralId { get; set; }
        [Required]
        public int DeceasedsProfileNumber { get; set; }
        [Required, StringLength(1000)]
        public string AddressForFuneral { get; set; }
        [ForeignKey("Statuses")]
        public int StatusId { get; set; }
        public string Comment { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        public DateTime Updated { get; set; }
        [Required]
        public int UpdatedBy { get; set; }


    }
}
