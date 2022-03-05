using API.AutoMapper;
using API.Services;
using AutoMapper;
using Common;
using Common.Helper;
using Common.Interface;
using Data.Command;
using Data.Repository;
using Data.Repository.Interface;
using GraphQL;
using Microsoft.Extensions.DependencyInjection;
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
            #region Common and command
            services.AddSingleton<ILogger, FileLogger>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddScoped<IDataEdtitorService, DataEdtitorService>();
            services.AddScoped<IDataEditorRepository, DataEditorRepository>();
            services.AddScoped<IDataExploreService, DataExploreService>();
            services.AddScoped<IDataExploreRepository, DataExploreRepository>();
            #endregion

            #region reponsitory admin
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
        
            services.AddTransient<ILoginAdminRepository, LoginAdminRepository>();
            services.AddTransient<IDataEditorRepository, DataEditorRepository>();
            #endregion
            
            #region service admin
         
            services.AddTransient<ILoginAdminService, LoginAdminService>();
            services.AddTransient<ILoginAdminService, LoginAdminService>();

            services.AddTransient<IDataEdtitorService, DataEdtitorService>();
            #endregion
            //  services.AddTransient<IServiceCollection>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();


            //AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
