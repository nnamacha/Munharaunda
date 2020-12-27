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
    public class ProfilesController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;

        public ProfilesController(IMunharaundaRepository db)
        {
           
            _db = db;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileResponse>>> GetProfile()
        {
            var response = await _db.GetProfiles();
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileResponse>> GetProfile(int id)
        {
            var response = await _db.GetProfile(id);
            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound();
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response);


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

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return NoContent();
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06 || (response.ResponseCode == ReturnCodesConstant.R07))
            {
                return BadRequest(response);
            }
            else 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {

            var response = await _db.CreateProfile(profile);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("GetProfile", response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
                

        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _db.GetProfile(id);

            if (profile == null)
            {
                return NotFound();
            }
            var response = await _db.DeleteProfile(id);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return NoContent();
            }
            else if(response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
                


        }



    }
}
