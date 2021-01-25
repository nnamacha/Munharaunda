using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.blazor.Pages
{
    public partial class Members
    {
        public ResponseModel<ProfileResponse> Profiles { get; set; }
        public string AlertLevel { get; set; } = "alert-info";
    }
}
