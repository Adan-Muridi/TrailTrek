using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailTrek.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";

        public string Secret { get; init; } = null!;
        public int ExpiryMinutes { get; init; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;

    }
}

/*assigns a value to the property or the indexer element only during object 
 * construction. This enforces immutability, so that once 
 * the object is initialized, it can't be changed again.*/

