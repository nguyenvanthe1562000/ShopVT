using API.Services;
using Common;
using Common.Helper;
using Common.Interface;
using Data.Command;
using Data.Reponsitory;
using Data.Reponsitory.Interface;
using Data.Repository;
using Data.Repository.Interface;
using GraphQL;
using Microsoft.Extensions.DependencyInjection;
using Model.Auth;
using Service.Admin.Service;
using Service.Admin.Service.Interface;
using Service.Command;
using Service.Command.Interface;
using ShopVT.Infrastructure.Respository;


namespace ShopVT.Extensions
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddDIConllection(this IServiceCollection services)
        {
            #region
            services.AddSingleton<ILogger, FileLogger>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddSingleton<IDataEdtitorService, DataEdtitorService>();
            services.AddSingleton<IDataEditorRepository, DataEditorRepository>();
            //services.AddSingleton<IDataExploreService, DataExploreService>();
            //services.AddSingleton<IDataEditorRepository, DataEditorRepository>();
            #endregion

            #region reponsitory admin
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IB10ProductRepository, B10ProductRepository>();
            services.AddTransient<IB00FunctionRpository, B00FunctionRepository>();
            services.AddTransient<IB00ContactRepository, B00ContactRepository>();
            services.AddTransient<ILoginAdminRepository, LoginAdminRepository>();
            services.AddTransient<IB10ProductImgRepository, B10ProductImgRepository>();
            services.AddTransient<IDataEditorRepository, DataEditorRepository>();
            #endregion
            
            #region service admin
            services.AddTransient<IB10ProductService, B10ProductService>();
            services.AddTransient<IB00FunctionService, B00FunctionService>();
            services.AddTransient<IB00ContactService, B00ContactService>();
            services.AddTransient<ILoginAdminService, LoginAdminService>();
            services.AddTransient<ILoginAdminService, LoginAdminService>();

            services.AddTransient<IDataEdtitorService, DataEdtitorService>();
            #endregion
            //  services.AddTransient<IServiceCollection>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            return services;
        }
    }
}
