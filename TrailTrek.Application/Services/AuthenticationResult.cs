using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Domain.Entities;

namespace TrailTrek.Application.Services
{
    public record AuthenticationResult(
        User user,
        string Token);
}
