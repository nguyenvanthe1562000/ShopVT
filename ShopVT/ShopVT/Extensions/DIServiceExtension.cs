using Common.Helper;
using Data.Reponsitory.Interface;
using Data.Reponsitory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Admin.Interface;
using Service.Admin.Service;
using ShopVT.Infrastructure.Respository;

namespace ShopVT.Extensions
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddDIConllection(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IB10ProductRepository, B10ProductRepository>();
            services.AddTransient<IB10ProductService, B10ProductService>();

            //chat
            services.AddTransient<IChatRepository, ChatRepository>();

            return services;
        }
    }
}
