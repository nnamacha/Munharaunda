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

        public StatusesController(IMunharaundaRepository db)
        {
           
            _db = db;
        }

        // GET: api/Statuses
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var response =  await _db.GetStatuses();

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound();
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        // GET: api/Statuses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatuses(int id)
        {
            var response = await _db.GetStatuses(id);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06Message)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
                
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

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return StatusCode(StatusCodes.Status202Accepted, response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            
        }

        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostStatuses(Statuses statuses)
        {
            var response = await _db.CreateStatus(statuses);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("GetStatuses",  statuses);
            }
            else 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            
        }

        // DELETE: api/Statuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatuses(int id)
        {
            var response = await _db.DeleteStatus(id);

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
