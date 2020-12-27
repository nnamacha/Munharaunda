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

        public FuneralController(IMunharaundaRepository Db)
        {

            _db = Db;
        }

        // GET: api/Funeral
        [HttpGet]
        public async Task<IActionResult> Funeral()
        {
            var response = await _db.GetFunerals();

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // GET: api/Funeral/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funeral>> Funeral(int id)
        {
            var response = await _db.GetFuneral(id);

            if (response.ResponseCode == ReturnCodesConstant.R06)
            {
                return NotFound(response);
            }
            else if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

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

        // POST: api/Funerals
        
        [HttpPost]
        public async Task<IActionResult> PostFuneral(Funeral funeral)
        {
            var response = await _db.CreateFuneral(funeral);

            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return CreatedAtAction("funeral", response.ResponseData[0]);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            
        }

        // DELETE: api/Funerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuneral(int id)
        {
            
            if (!_db.FuneralExists(id))
            {
                return NotFound();
            }


            var response = await _db.DeleteFuneral(id);

            if (response.ResponseCode ==  ReturnCodesConstant.R00)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            
        }

        private bool FuneralExists(int id)
        {
            return _db.FuneralExists(id);
        }
    }
}
