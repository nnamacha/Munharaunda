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
        private readonly IResponsesService _responsesService;

        public TransactionCodesController(IMunharaundaRepository db, IResponsesService responsesService)
        {
            
            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/TransactionCodes
        [HttpGet]
        public async Task<IActionResult> GetTransactionCodes()
        {
            var response = await _db.GetTransactionCodes();

            return _responsesService.GetResponse(response);
        }

        // GET: api/TransactionCodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionCodes(int id)
        {
            var response = await _db.GetTransactionCode(id);

            return _responsesService.GetResponse(response);
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

            return _responsesService.PutResponse(response);
        }

        // POST: api/TransactionCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTransactionCodes(TransactionCodes transactionCodes)
        {

            var response = await _db.CreateTransactionCode(transactionCodes);

            return _responsesService.PostResponse(response);

        }

        // DELETE: api/TransactionCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionCodes(int id)
        {
            var response = await _db.DeleteTransactionCode(id);

            return _responsesService.DeleteResponse(response);
        }

    
    }
}
