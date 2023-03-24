//using Microsoft.AspNetCore.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailTrek.Application.Authentication.Commands.Register;
using TrailTrek.Application.Authentication.Common;
using TrailTrek.Application.Authentication.Queries.Login;
using TrailTrek.Contracts.Authentication;
using TrailTrek.Domain.Common.Errors;

namespace TrailTrek.Api.Controllers
{
    //[Route("api/auth")]
    [Route("auth")]
    public class AuthenticationController : ApiController
    {

        private readonly ISender _mediator; // Replace IMediator with ISender for Inteface segrigation principle

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

            ErrorOr.ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);


            //ErrorOr.ErrorOr<AuthenticationResult> authResult = await _mediator.Send.Register(
            //    request.FirstName,
            //    request.LastName,
            //    request.Email,
            //    request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }
        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                        authResult.User.Id,
                        authResult.User.FirstName,
                        authResult.User.LastName,
                        authResult.User.Email,
                        authResult.Token);
        }
    }
}
