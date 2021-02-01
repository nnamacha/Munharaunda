using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.MVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IApiClient _apiClient;

        public MemberController(ILogger<MemberController> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await _apiClient.GetAllProfiles());
        }

        public async Task<IActionResult> Details(string id)
        {
            int profileNumber;

            if (Int32.TryParse(id, out profileNumber))
            {
                return View( await _apiClient.GetProfileById(profileNumber));
            }
            else
            {

                return NotFound();
            }
        }
    }
}
