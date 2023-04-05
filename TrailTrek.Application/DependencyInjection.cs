using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Net.NetworkInformation;
using System.Reflection;
using FluentValidation;
using TrailTrek.Application.Authentication.Common.Behaviors;
using TrailTrek.Application;

namespace TrailTrek.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}


// This Works!!!


//services.AddMediatR(cfg => {
//    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
//    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
//});