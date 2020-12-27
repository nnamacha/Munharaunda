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
        private readonly MunharaundaDbContext _context;
        private readonly IMunharaundaRepository _db;

        public ProfileTypesController(MunharaundaDbContext context, IMunharaundaRepository db)
        {

            _db = db;
        }

        // GET: api/ProfileTypes
        [HttpGet]
        public async Task<IActionResult> GetProfileTypes()
        {
            var response = await _db.GetProfileTypes();

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }


        }

        // GET: api/ProfileTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileTypes(int id)
        {
            var response = await _db.GetProfileTypes(id);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

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

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return StatusCode(StatusCodes.Status202Accepted, response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }

        // POST: api/ProfileTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProfileTypes(ProfileTypes profileTypes)
        {

            var response = await _db.CreateProfileType(profileTypes);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("GetProfileTypes", response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }

        // DELETE: api/ProfileTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileTypes(int id)
        {
            var response = await _db.DeleteProfileType(id);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return StatusCode(StatusCodes.Status202Accepted, response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            
        }


    }
}
