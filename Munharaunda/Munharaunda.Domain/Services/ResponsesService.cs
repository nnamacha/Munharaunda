using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Munharaunda.Core.Constants;
using Munharaunda.Domain.Contracts;
using Munharaunda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Domain.Services
{
    public class ResponsesService : ControllerBase, IResponsesService
    {
        public IActionResult GetResponse<T>(ResponseModel<T> response)
        {
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

        public IActionResult PutResponse<T>(ResponseModel<T> response)
        {
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

        public IActionResult PostResponse<T>(ResponseModel<T> response)
        {
            if (response.ResponseCode == ReturnCodesConstant.R00)
            {
                return StatusCode(StatusCodes.Status201Created, response); ;
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        public IActionResult DeleteResponse<T>(ResponseModel<T> response)
        {
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
