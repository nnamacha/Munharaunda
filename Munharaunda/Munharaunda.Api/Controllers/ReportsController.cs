using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Munharaunda.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMunharaundaRepository _db;
        private readonly IResponsesService _responsesService;

        public ReportsController(IMunharaundaRepository db, IResponsesService responsesService)
        {
            _db = db;
            _responsesService = responsesService;
        }

        [HttpGet("FuneralsPaidByProfile/{id}/{paid}")]

        public async Task<IActionResult> FuneralsPaidByProfile(int id, bool paid)
        {
            var response = await _db.GetFuneralsPaidByProfile(id,paid);

            return _responsesService.GetResponse(response);
        }
    }
}
