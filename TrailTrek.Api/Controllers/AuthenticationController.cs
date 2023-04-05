//using Microsoft.AspNetCore.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {

        private readonly ISender _mediator; // Replace IMediator with ISender for Inteface segrigation principle
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr.ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

        }
    }
}
