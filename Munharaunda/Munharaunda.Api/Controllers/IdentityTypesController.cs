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
    public class IdentityTypesController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;
        private readonly IResponsesService _responsesService;

        public IdentityTypesController(IMunharaundaRepository db, IResponsesService responsesService)
        {
            
            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/IdentityType
        [HttpGet]
        public async Task<IActionResult> GetIdentityTypes()
        {
            var response = await _db.GetIdentityTypes();

            return _responsesService.GetResponse(response);
        }

        // GET: api/IdentityType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdentityTypes(int id)
        {
            var response = await _db.GetIdentityType(id);

            return _responsesService.GetResponse(response);
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

            return _responsesService.PutResponse(response);


        }

        // POST: api/IdentityType
       
        [HttpPost]
        public async Task<IActionResult> PostIdentityTypes(IdentityTypes identityTypes)
        {
            var response = await _db.CreateIdentityType(identityTypes);

            return _responsesService.PostResponse(response);

        }

        // DELETE: api/IdentityType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentityTypes(int id)
        {
            
            var response = await _db.DeleteIdentityType(id);

            return _responsesService.DeleteResponse(response);
        }


        
    }
}
