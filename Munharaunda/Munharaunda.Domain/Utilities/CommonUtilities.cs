using Microsoft.Extensions.Configuration;
using Munharaunda.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Utilities
{
    public class CommonUtilities:ICommonUtilities
    {
        private readonly IConfiguration _config;

        public CommonUtilities(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void LogMessage(string message)
        {

        }
    }
}
