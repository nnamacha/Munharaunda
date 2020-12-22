using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Munharaunda.Domain.Models
{
    public class ProfileTypes
    {
        [Key]
        public int ProfileTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        
    }
}
