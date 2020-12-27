using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionCodesController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;

        public TransactionCodesController(IMunharaundaRepository db)
        {
            
            _db = db;
        }

        // GET: api/TransactionCodes
        [HttpGet]
        public async Task<IActionResult> GetTransactionCodes()
        {
            var response = await _db.GetTransactionCodes();

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

        // GET: api/TransactionCodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionCodes(int id)
        {
            var response = await _db.GetTransactionCode(id);

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

        // PUT: api/TransactionCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionCodes(int id, TransactionCodes transactionCodes)
        {
            if (id != transactionCodes.TransactionCodeId)
            {
                return BadRequest();
            }

            var response = await _db.UpdateTransactionCodes(id, transactionCodes);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return NoContent();
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

        // POST: api/TransactionCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionCodes>> PostTransactionCodes(TransactionCodes transactionCodes)
        {

            var response = await _db.CreateTransactionCode(transactionCodes);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("GetTransactionCodes", response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
           
        }

        // DELETE: api/TransactionCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionCodes(int id)
        {
            var response = await _db.DeleteTransactionCode(id);

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

    
    }
}
