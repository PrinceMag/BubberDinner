using BuberDinner.Application.Common.Interfaces.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            var (statusCode, message) = exception switch
            {
                IServiceExption serviceExption => ((int)serviceExption.StatusCode,serviceExption.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError,"An unexpected error occurred")
            };
            return Problem(statusCode: statusCode,title: message);
        }
    }
}
