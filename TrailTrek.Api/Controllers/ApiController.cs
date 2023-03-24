using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailTrek.Api.common.Http;

namespace TrailTrek.Api.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            //if (errors.Count is 0)
            //{
            //    return Problem();
            //}

            //if (errors.All(error => error.Type == ErrorType.Validation))
            //{
            //    return ValidationProblem(errors);
            //}

            //HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            //return Problem(errors[0]);



            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode,title:firstError.Description);

        }
    }
}
