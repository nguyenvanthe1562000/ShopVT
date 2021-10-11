using Common.Helper;
using Data.Reponsitory;
using Data.Reponsitory.Interface;
using Data.Repository;
using Data.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service.Admin.Service;
using Service.Admin.Service.Interface;
using ShopVT.Infrastructure.Respository;


namespace ShopVT.Extensions
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddDIConllection(this IServiceCollection services)
        {
            #region reponsitory admin
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IB10ProductRepository, B10ProductRepository>();
            services.AddTransient<ILoginAdminRepository, LoginAdminRepository>();
            #endregion

            #region service admin
            services.AddTransient<IB10ProductService, B10ProductService>();
            services.AddTransient<ILoginAdminService, LoginAdminService>();
            #endregion

            services.AddTransient<IChatRepository, ChatRepository>();

            return services;
        }
    }
}
