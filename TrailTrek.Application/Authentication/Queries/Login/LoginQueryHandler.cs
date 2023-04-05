using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Application.Common.Interfaces.Authentication;
using TrailTrek.Application.Common.Interfaces.Persistence;
using TrailTrek.Application.Authentication.Common;
using TrailTrek.Domain.Common.Errors;
using TrailTrek.Domain.Entities;
using MapsterMapper;

namespace TrailTrek.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(query.Email) is not User user)
                return Errors.Authentication.InvalidCredentials;


            if (user.Password != query.Password)
                return Errors.Authentication.InvalidCredentials;


            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(
                user,
                token);
        }
    }
}
