using Common.Helper;
using Data.Reponsitory;
using Data.Reponsitory.Interface;
using Data.Repository;
using Data.Repository.Interface;
using GraphQL;
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
            services.AddTransient<IB00FunctionRpository, B00FunctionRepository>();
            services.AddTransient<ILoginAdminRepository, LoginAdminRepository>();
            #endregion

            #region service admin
            services.AddTransient<IB10ProductService, B10ProductService>();
            services.AddTransient<IB00FunctionService, B00FunctionService>();
            services.AddTransient<ILoginAdminService, LoginAdminService>();
            #endregion

            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            return services;
        }
    }
}
