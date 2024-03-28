using Application.Queries.GreenHouseQuery;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // register all Commands, Queries and Domain event handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetGreenHousesQueryHandler).Assembly));
            return services;
        }
    }
}
