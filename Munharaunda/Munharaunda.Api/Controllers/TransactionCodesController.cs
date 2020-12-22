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
    public class TransactionCodesController : ControllerBase
    {
        private readonly MunharaundaDbContext _context;

        public TransactionCodesController(MunharaundaDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionCodes>>> GetTransactionCodes()
        {
            return await _context.TransactionCodes.ToListAsync();
        }

        // GET: api/TransactionCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionCodes>> GetTransactionCodes(int id)
        {
            var transactionCodes = await _context.TransactionCodes.FindAsync(id);

            if (transactionCodes == null)
            {
                return NotFound();
            }

            return transactionCodes;
        }

        // PUT: api/TransactionCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionCodes(int id, TransactionCodes transactionCodes)
        {
            if (id != transactionCodes.TransactionCodeId)
            {
                return BadRequest();
            }

            _context.Entry(transactionCodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionCodesExists(id))
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

        // POST: api/TransactionCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionCodes>> PostTransactionCodes(TransactionCodes transactionCodes)
        {
            _context.TransactionCodes.Add(transactionCodes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionCodes", new { id = transactionCodes.TransactionCodeId }, transactionCodes);
        }

        // DELETE: api/TransactionCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionCodes(int id)
        {
            var transactionCodes = await _context.TransactionCodes.FindAsync(id);
            if (transactionCodes == null)
            {
                return NotFound();
            }

            _context.TransactionCodes.Remove(transactionCodes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionCodesExists(int id)
        {
            return _context.TransactionCodes.Any(e => e.TransactionCodeId == id);
        }
    }
}
