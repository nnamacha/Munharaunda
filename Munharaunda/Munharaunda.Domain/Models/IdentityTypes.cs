using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Munharaunda.Domain.Models
{
    public class IdentityTypes
    {
        [Key]
        public int IdentityTypeId { get; set; }
        [Required]
        public string Description { get; set; }

       //public ICollection<Profile> Profiles { get; set; }
    }
}
