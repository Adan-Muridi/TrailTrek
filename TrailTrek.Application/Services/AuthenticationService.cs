using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Application.Common.Interfaces.Authentication;
using TrailTrek.Application.Common.Interfaces.Persistence;
using TrailTrek.Domain.Entities;

namespace TrailTrek.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with give email does NOT exist");
            }

            if (user.Password != password)
                throw new Exception("Invalid password");

            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(
                user,
                token);

            //var user = _userRepository.GetUserByEmail(email);

            //if (user == null)
            //    throw new Exception("User with give email does NOT exist");


            //if(user.password != password )
            //    throw new Exception("Invalid password");

        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) != null) 
                throw new Exception("User with give email already exists");


            var user= new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
