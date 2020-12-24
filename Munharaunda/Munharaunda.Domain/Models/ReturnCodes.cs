using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Models
{
    public class ReturnCodes
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}
