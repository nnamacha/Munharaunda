using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;

namespace Munharaunda.Web.Pages
{
    public class MembersListModel : PageModel
    {
        private readonly ILogger<MembersListModel> _logger;
        private readonly IApiClient _apiClient;
        public ResponseModel<ProfileResponse> Profiles { get; set; }

        public MembersListModel(ILogger<MembersListModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        public async Task OnGet()
        {
            Profiles = await _apiClient.GetAllProfiles();
        }
    }
}
