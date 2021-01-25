using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;

namespace Munharaunda.Web.Pages.members
{
    
    public class ProfileModel : PageModel
    {
        private readonly Logger<MembersListModel> _logger;
        private readonly IApiClient _apiClient;

        public ProfileModel(Logger<MembersListModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        public ResponseModel<ProfileResponse> Profile { get; set; }

        [BindProperty(SupportsGet =true)]
        public int ProfileId { get; set; }
        public async Task OnGet()
        {
            Profile = await _apiClient.GetProfileById(ProfileId);
        }
    }
}
