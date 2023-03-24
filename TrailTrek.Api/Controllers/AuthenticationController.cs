//using Microsoft.AspNetCore.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrailTrek.Application.Services.Authentication.Commands;
using TrailTrek.Application.Services.Authentication.Common;
using TrailTrek.Application.Services.Authentication.Queries;
using TrailTrek.Contracts.Authentication;
using TrailTrek.Domain.Common.Errors;

namespace TrailTrek.Api.Controllers
{
    //[Route("api/auth")]
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationService,
                                        IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr.ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(request.Email, request.Password);

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
                        authResult.user.Id,
                        authResult.user.FirstName,
                        authResult.user.LastName,
                        authResult.user.Email,
                        authResult.Token);
        }
    }
}
