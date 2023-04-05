
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TrailTrek.Api.common.Errors;
using TrailTrek.Api.Common.Mapping;

namespace TrailTrek.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();

            services.AddSingleton<ProblemDetailsFactory, TrailTreckProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}
