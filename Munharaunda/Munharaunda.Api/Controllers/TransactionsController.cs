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
        private readonly IResponsesService _responsesService;

        public TransactionsController(IMunharaundaRepository db, IResponsesService responsesService)
        {

            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var response = await _db.GetTransactions();

            return _responsesService.GetResponse(response);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactions(int id)
        {
            var response = await _db.GetTransaction(id);

            return _responsesService.GetResponse(response);
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

            return _responsesService.PutResponse(response);
        }

        // POST: api/Transactions
        
        [HttpPost]
        public async Task<IActionResult> PostTransactions(Transactions transactions)
        {
            var response = await _db.CreateTransaction(transactions);

            return _responsesService.PostResponse(response);


        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactions(int id)
        {

            var response = await _db.DeleteTransaction(id);

            return _responsesService.DeleteResponse(response);
        }
    }

      
}
