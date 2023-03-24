using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTrek.Application.Services
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthenticationResult> Register(string firstname, string lastname, string email, string password);
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
