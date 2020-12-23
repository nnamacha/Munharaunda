using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileTypesController : ControllerBase
    {
        private readonly MunharaundaDbContext _context;

        public ProfileTypesController(MunharaundaDbContext context)
        {
            _context = context;
        }

        // GET: api/ProfileTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileTypes>>> GetProfileTypes()
        {
            return await _context.ProfileTypes.ToListAsync();
        }

        // GET: api/ProfileTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileTypes>> GetProfileTypes(int id)
        {
            var profileTypes = await _context.ProfileTypes.FindAsync(id);

            if (profileTypes == null)
            {
                return NotFound();
            }

            return profileTypes;
        }

        // PUT: api/ProfileTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileTypes(int id, ProfileTypes profileTypes)
        {
            if (id != profileTypes.ProfileTypeId)
            {
                return BadRequest();
            }

            _context.Entry(profileTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileTypesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProfileTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfileTypes>> PostProfileTypes(ProfileTypes profileTypes)
        {
            _context.ProfileTypes.Add(profileTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfileTypes", new { id = profileTypes.ProfileTypeId }, profileTypes);
        }

        // DELETE: api/ProfileTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileTypes(int id)
        {
            var profileTypes = await _context.ProfileTypes.FindAsync(id);
            if (profileTypes == null)
            {
                return NotFound();
            }

            _context.ProfileTypes.Remove(profileTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileTypesExists(int id)
        {
            return _context.ProfileTypes.Any(e => e.ProfileTypeId == id);
        }
    }
}
