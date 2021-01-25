using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;
        private readonly IResponsesService _responsesService;

        public ProfileController(IMunharaundaRepository db, IResponsesService responsesService)
        {
           
            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var response = await _db.GetProfiles();

            return _responsesService.GetResponse(response);
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var dbResponse = await _db.GetProfile(id);

            if (dbResponse.ResponseCode == ReturnCodesConstant.R00)
            {
                var response = await _db.GenerateProfileDetails(dbResponse.ResponseData[0]);               

                return _responsesService.GetResponse(response);
            }
            else
            {
                return _responsesService.GetResponse(dbResponse);
            }    
            


        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.ProfileNumber)
            {
                return BadRequest();
            }

            var response = await _db.UpdateProfile(id, profile);

            return _responsesService.PutResponse(response);

        }

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProfile(Profile profile)
        {

            var response = await _db.CreateProfile(profile);

            return _responsesService.PostResponse(response);


        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var response = await _db.DeleteProfile(id);

            return _responsesService.DeleteResponse(response);



        }



    }
}
