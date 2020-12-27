using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityTypesController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;

        public IdentityTypesController(IMunharaundaRepository db)
        {
            
            _db = db;
        }

        // GET: api/IdentityType
        [HttpGet]
        public async Task<IActionResult> GetIdentityTypes()
        {
            var response = await _db.GetIdentityTypes();

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

        // GET: api/IdentityType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdentityTypes(int id)
        {
            var response = await _db.GetIdentityType(id);

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

        // PUT: api/IdentityType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentityTypes(int id, IdentityTypes identityTypes)
        {
            if (id != identityTypes.IdentityTypeId)
            {
                return BadRequest();
            }

            var response = await _db.UpdateIdentityType(id, identityTypes);

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

        // POST: api/IdentityType
       
        [HttpPost]
        public async Task<IActionResult> PostIdentityTypes(IdentityTypes identityTypes)
        {
            var response = await _db.CreateIdentityType(identityTypes);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("GetIdentityTypes", response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            
        }

        // DELETE: api/IdentityType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentityTypes(int id)
        {
            
            if (!_db.IdentityTypeExists(id))
            {
                return NotFound();
            }

            var response = await _db.DeleteIdentityType(id);

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

        
    }
}
