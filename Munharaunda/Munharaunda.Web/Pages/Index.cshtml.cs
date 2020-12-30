using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiClient _apiClient;

        public ResponseModel<Profile> Profile { get; set; }
        public ResponseModel<ActiveFuneralResponse> ActiveFunerals { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient )
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task OnGet()
        {
            ActiveFunerals = await _apiClient.GetActiveFunerals();
        }
    }
}
