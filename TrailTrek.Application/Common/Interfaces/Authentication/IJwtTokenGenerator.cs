using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Domain.Entities;

namespace TrailTrek.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        String GenerateToken(User user);
    }
}
