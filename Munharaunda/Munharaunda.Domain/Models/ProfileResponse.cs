using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Models
{
    public class ProfileResponse : Profile
    {
        public ICollection<ActiveFuneralResponse> PaidFuneral { get; set; } = new List<ActiveFuneralResponse>();
        public ICollection<ActiveFuneralResponse> NotPaidFuneral { get; set; } = new List<ActiveFuneralResponse>();
        public virtual string FullName { get; set;  }
        public virtual IdentityTypes IdentityType { get; set; }
        public virtual string StatusDescription { get; set; }

        public ProfileTypes ProfileType { get; set; }
    }
}
