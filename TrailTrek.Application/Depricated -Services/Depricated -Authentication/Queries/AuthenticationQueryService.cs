//using ErrorOr;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TrailTrek.Application.Common.Interfaces.Authentication;
//using TrailTrek.Application.Common.Interfaces.Persistence;
//using TrailTrek.Application.Services.Authentication.Common;
//using TrailTrek.Domain.Common.Errors;
//using TrailTrek.Domain.Entities;

//namespace TrailTrek.Application.Services.Authentication.Queries
//{
//    public class AuthenticationQueryService : IAuthenticationQueryService
//    {
//        private readonly IJwtTokenGenerator _jwtTokenGenerator;
//        private readonly IUserRepository _userRepository;

//        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
//        {
//            _jwtTokenGenerator = jwtTokenGenerator;
//            _userRepository = userRepository;
//        }

//        public ErrorOr<AuthenticationResult> Login(string email, string password)
//        {
//            if (_userRepository.GetUserByEmail(email) is not User user)
//                return Errors.Authentication.InvalidCredentials;


//            if (user.Password != password)
//                return Errors.Authentication.InvalidCredentials;


//            var token = _jwtTokenGenerator.GenerateToken(user);


//            return new AuthenticationResult(
//                user,
//                token);

//            //var user = _userRepository.GetUserByEmail(email);

//            //if (user == null)
//            //    throw new Exception("User with give email does NOT exist");


//            //if(user.password != password )
//            //    throw new Exception("Invalid password");

//        }

//        //public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
//        //{
//        //    if (_userRepository.GetUserByEmail(email) != null)
//        //        return Errors.User.DuplicateEmail;


//        //    var user = new User
//        //    {
//        //        FirstName = firstName,
//        //        LastName = lastName,
//        //        Email = email,
//        //        Password = password
//        //    };

//        //    _userRepository.Add(user);

//        //    var token = _jwtTokenGenerator.GenerateToken(user);

//        //    return new AuthenticationResult(
//        //        user,
//        //        token);
//        //}
//    }
//}
