using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;
using System.Threading.Tasks;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileTypesController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;
        private readonly IResponsesService _responsesService;

        public ProfileTypesController(IMunharaundaRepository db, IResponsesService responsesService)
        {

            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/ProfileTypes
        [HttpGet]
        public async Task<IActionResult> GetProfileTypes()
        {
            var response = await _db.GetProfileTypes();

            return _responsesService.GetResponse(response);

        }

       

        // GET: api/ProfileTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileTypes(int id)
        {
            var response = await _db.GetProfileTypes(id);

            return _responsesService.GetResponse(response);

        }

        // PUT: api/ProfileTypes/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileTypes(int id, ProfileTypes profileTypes)
        {
            if (id != profileTypes.ProfileTypeId)
            {
                return BadRequest();
            }

            var response = await _db.UpdateProfileType(id, profileTypes);

            return _responsesService.PutResponse(response);

        }

        

        // POST: api/ProfileTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProfileTypes(ProfileTypes profileTypes)
        {

            var response = await _db.CreateProfileType(profileTypes);

            return _responsesService.PostResponse(response);

        }

        

        // DELETE: api/ProfileTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileTypes(int id)
        {
            var response = await _db.DeleteProfileType(id);

            return _responsesService.DeleteResponse(response);

        }

        
    }
}
