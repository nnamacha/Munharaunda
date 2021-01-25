using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using Munharaunda.Infrastructure.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Munharaunda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuneralController : ControllerBase
    {
        
        private readonly IMunharaundaRepository _db;
        private readonly IResponsesService _responsesService;

        public FuneralController(IMunharaundaRepository db, IResponsesService responsesService)
        {

            _db = db;
            _responsesService = responsesService;
        }

        // GET: api/Funeral
        [HttpGet]
        public async Task<IActionResult> Funeral()
        {
            var response = await _db.GetFunerals();

            return _responsesService.GetResponse(response);
        }

        // GET: api/Funeral/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Funeral(int id)
        {
            var response = await _db.GetFuneral(id);

            return _responsesService.GetResponse(response);

        }

        //GET:api/Funeral/Active
        [HttpGet("Active")]

        public async Task<IActionResult> ActiveFuneral()
        {
            var response = await _db.GetActiveFuneral();

            return _responsesService.GetResponse(response);
        }

        
        // PUT: api/Funerals/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuneral(int id, Funeral funeral)
        {
            if (id != funeral.FuneralId)
            {
                return BadRequest();
            }

            var response = await _db.UpdateFuneral(id, funeral);

           

            return _responsesService.PutResponse(response);

            
        }

        // POST: api/Funerals
        
        [HttpPost]
        public async Task<IActionResult> PostFuneral(Funeral funeral)
        {
            var response = await _db.CreateFuneral(funeral);

            return _responsesService.PostResponse(response);

        }

        // DELETE: api/Funerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuneral(int id)
        {
           
            var response = await _db.DeleteFuneral(id);

            return _responsesService.DeleteResponse(response);


        }

        
    }
}
