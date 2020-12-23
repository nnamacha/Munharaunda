using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Munharaunda.Core.Dto
{
    public class ProfileDto
    {
        [Key]
        public int ProfileNumber { get; set; }

        [Required]
        public int ProfileTypeId { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int IdentityTypeId { get; set; }

        [Required]
        public int NextOfKin { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public int Status { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public DateTime Updated { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ActiveDate { get; set; }
        [Required]
        public bool ReOpen { get; set; }

        public int ReOpenedBy { get; set; }
        [Required]
        public DateTime ReOpened { get; set; }

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
