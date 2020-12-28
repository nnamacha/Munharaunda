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
    public class StatusesController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;
        private readonly IResponsesService _responsesService;

        public StatusesController(IMunharaundaRepository db, IResponsesService responsesService)
        {
           
            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var response =  await _db.GetStatuses();

            return _responsesService.GetResponse(response);
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatuses(int id)
        {
            var response = await _db.GetStatuses(id);

            return _responsesService.GetResponse(response);

        }

        // PUT: api/Statuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatuses(int id, Statuses statuses)
        {
            if (id != statuses.StatusId)
            {
                return BadRequest();
            }

            var response = await _db.UpdateStatuses(id, statuses);

            return _responsesService.PutResponse(response);


        }

        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostStatuses(Statuses statuses)
        {
            var response = await _db.CreateStatus(statuses);

            return _responsesService.PostResponse(response);


        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatuses(int id)
        {
            var response = await _db.DeleteStatus(id);

            return _responsesService.DeleteResponse(response);
        }

       
    }
}
