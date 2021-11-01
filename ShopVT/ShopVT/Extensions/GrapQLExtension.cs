using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShopVT.Extensions
{
    public static class GrapQLExtension
    {
        public static IServiceCollection AddGrapQLExtension(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddProjections()
                    .AddFiltering()
                    .AddSorting();
            return services;
        }
    }
}
