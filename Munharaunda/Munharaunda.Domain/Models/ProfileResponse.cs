using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Models
{
    public class ProfileResponse : Profile
    {
        public ICollection<Funeral> PaidFuneral { get; set; } = new List<Funeral>();
        public virtual string FullName { get; set;  }
        public virtual IdentityTypes IdentityType { get; set; }

        public ProfileTypes ProfileType { get; set; }
    }
}
