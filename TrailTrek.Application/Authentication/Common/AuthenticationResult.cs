using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Domain.Entities;

namespace TrailTrek.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
