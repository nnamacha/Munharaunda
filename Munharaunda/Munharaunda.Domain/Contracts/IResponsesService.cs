using Microsoft.AspNetCore.Mvc;
using Munharaunda.Domain.Models;

namespace Munharaunda.Domain.Contracts
{
    public interface IResponsesService
    {
        IActionResult DeleteResponse<T>(ResponseModel<T> response);
        IActionResult GetResponse<T>(ResponseModel<T> response);
        IActionResult PostResponse<T>(ResponseModel<T> response);
        IActionResult PutResponse<T>(ResponseModel<T> response);
    }
}