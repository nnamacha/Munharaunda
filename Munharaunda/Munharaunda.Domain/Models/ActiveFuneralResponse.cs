using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Models
{
    public class ActiveFuneralResponse : Funeral
    {
        public string DeceasedFullName { get; set; }
        public string DeceasedProfileStatus { get; set; }

    }
}
