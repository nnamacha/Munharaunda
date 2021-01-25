using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Munharaunda.Core.Constants;
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

        [BindProperty(SupportsGet = true)]
        public string ProfileId { get; set; }
        
        public async Task OnGet()
        {
            if (string.IsNullOrWhiteSpace(ProfileId))
            {
                Profiles = await _apiClient.GetAllProfiles();
            }
            else
            {
                int profileNumber;

                if (Int32.TryParse(ProfileId, out profileNumber))
                {
                    Profiles = await _apiClient.GetProfileById(profileNumber);
                }
                else
                {

                    Profiles = new ResponseModel<ProfileResponse>
                    {
                        ResponseCode = ReturnCodesConstant.R06

                    };
                }
                
            }
        }
    }
}
