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
    public class TransactionsController : ControllerBase
    {

        private readonly IMunharaundaRepository _db;

        public TransactionsController(IMunharaundaRepository db)
        {

            _db = db;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var response = await _db.GetTransactions();


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

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactions(int id)
        {
            var response = await _db.GetTransaction(id);

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

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactions(int id, Transactions transactions)
        {
            if (id != transactions.TransactionId)
            {
                return BadRequest();
            }

            var response = await _db.UpdateTransactions(id, transactions);

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

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transactions>> PostTransactions(Transactions transactions)
        {
            var response = await _db.CreateTransaction(transactions);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("GetTransactions", response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }


        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactions(int id)
        {

            var response = await _db.DeleteTransaction(id);

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
