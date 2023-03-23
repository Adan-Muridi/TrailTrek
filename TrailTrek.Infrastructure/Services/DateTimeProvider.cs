using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Application.Common.Services;

namespace TrailTrek.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        // Expression body property

        public DateTime UtcNow => DateTime.UtcNow;

        // Block body property
        //public DateTime UtcNow
        //{
        //    get
        //    {
        //        return DateTime.UtcNow;
        //    }
        //}
    }
}
