using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastucture.Database;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityTypesController : ControllerBase
    {
        private readonly MunharaundaDbContext _context;

        public IdentityTypesController(MunharaundaDbContext context)
        {
            _context = context;
        }

        // GET: api/IdentityType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityTypes>>> GetIdentityTypes()
        {
            return await _context.IdentityTypes.ToListAsync();
        }

        // GET: api/IdentityType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityTypes>> GetIdentityTypes(int id)
        {
            var identityTypes = await _context.IdentityTypes.FindAsync(id);

            if (identityTypes == null)
            {
                return NotFound();
            }

            return identityTypes;
        }

        // PUT: api/IdentityType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentityTypes(int id, IdentityTypes identityTypes)
        {
            if (id != identityTypes.IdentityTypeId)
            {
                return BadRequest();
            }

            _context.Entry(identityTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityTypesExists(id))
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

        // POST: api/IdentityType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdentityTypes>> PostIdentityTypes(IdentityTypes identityTypes)
        {
            _context.IdentityTypes.Add(identityTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentityTypes", new { id = identityTypes.IdentityTypeId }, identityTypes);
        }

        // DELETE: api/IdentityType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentityTypes(int id)
        {
            var identityTypes = await _context.IdentityTypes.FindAsync(id);
            if (identityTypes == null)
            {
                return NotFound();
            }

            _context.IdentityTypes.Remove(identityTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdentityTypesExists(int id)
        {
            return _context.IdentityTypes.Any(e => e.IdentityTypeId == id);
        }
    }
}
