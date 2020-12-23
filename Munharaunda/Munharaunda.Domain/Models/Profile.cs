using Munharaunda.Core.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Munharaunda.Domain.Models
{
    public class Profile : ProfileDto
    {

        public virtual ICollection<Funeral> PaidFuneral { get; set; } = new List<Funeral>();






    }
}
