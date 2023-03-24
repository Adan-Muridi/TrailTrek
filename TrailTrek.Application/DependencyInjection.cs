using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Net.NetworkInformation;


namespace TrailTrek.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            //services.AddMediatR(cfg => {
            //    cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            //    cfg.AddBehavior<IPipelineBehavior<Ping, Pong>, PingPongBehavior>();
            //    cfg.AddOpenBehavior(typeof(GenericBehavior<,>));
            //});

            return services;
        }
    }
}
