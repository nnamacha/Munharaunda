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
    public class FuneralController : ControllerBase
    {
        private readonly MunharaundaDbContext _context;

        public FuneralController(MunharaundaDbContext context)
        {
            _context = context;
        }

        // GET: api/Funeral
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funeral>>> Funeral()
        {
            return await _context.Funeral.ToListAsync();
        }

        // GET: api/Funeral/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funeral>> Funeral(int id)
        {
            var funeral = await _context.Funeral.FindAsync(id);

            if (funeral == null)
            {
                return NotFound();
            }

            return funeral;
        }

        // PUT: api/Funerals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuneral(int id, Funeral funeral)
        {
            if (id != funeral.FuneralId)
            {
                return BadRequest();
            }

            _context.Entry(funeral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuneralExists(id))
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

        // POST: api/Funerals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funeral>> PostFuneral(Funeral funeral)
        {
            _context.Funeral.Add(funeral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("funeral", new { id = funeral.FuneralId }, funeral);
        }

        // DELETE: api/Funerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuneral(int id)
        {
            var funeral = await _context.Funeral.FindAsync(id);
            if (funeral == null)
            {
                return NotFound();
            }

            _context.Funeral.Remove(funeral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuneralExists(int id)
        {
            return _context.Funeral.Any(e => e.FuneralId == id);
        }
    }
}
