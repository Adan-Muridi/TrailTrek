using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailTrek.Application.Common.Interfaces.Authentication;
using TrailTrek.Application.Common.Interfaces.Persistence;
using TrailTrek.Application.Common.Services;
using TrailTrek.Application.Services.Authentication.Commands;
using TrailTrek.Infrastructure.Authentication;
using TrailTrek.Infrastructure.Persistence;
using TrailTrek.Infrastructure.Services;

namespace TrailTrek.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            //services.AddSingleton<IJwtGenerator, JwtGenerator>();


            services.AddScoped<IUserRepository, UserRepository>();  // Scoped will creaate new list of users for every request

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();



            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

            return services;
        }
    }
}
