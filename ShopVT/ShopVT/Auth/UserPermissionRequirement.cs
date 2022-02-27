using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Model.Auth;
using Service.Admin.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace ShopVT.Auth
{
    //public class UserPermissionAttribute : TypeFilterAttribute
    //{
    //    public UserPermissionAttribute(PermissionFunction permissionFunction) : base(typeof(RequirePermissionsAttribute))
    //    {
    //        Arguments = new object[] {permissionFunction};
    //    }
    //}
    public class RequirePermissionsAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private static bool _requireApplicationAccessPermission = Startup.Configuration.GetValue<bool>("IdentitySettings:RequireApplicationAccessPermission");

        public List<PermissionFunction> Permissions { get; }

        public RequirePermissionsAttribute(params PermissionFunction[] permissions)
        {
            //Permissions = new List<PermissionFunction>() { permissions };
            Permissions = permissions.ToList();
        }

        public  void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    context.Result = new ForbidResult();
                    return;
                }

                var permisionUser = Startup.ServiceProvider.GetService(typeof(IPermissionService)) as IPermissionService;
                var permission= permisionUser.GetPermissionFunctions(Convert.ToInt32(userId));


                if (!_requireApplicationAccessPermission)
                {
                    // if not require application access
                    // => every one with valid user account can use this app
                    // => auto add user to application
                    
                    return;
                }
                if (permission.Contains(PermissionFunction.ApplicationAdmin))
                    return;
                // check application access permission
                var hasAccessApplicationPermission = permission.Contains(PermissionFunction.AccessApplication);
                if (!hasAccessApplicationPermission)
                {
                    context.Result = new ForbidResult();
                    return;
                }

                foreach (var item in Permissions)
                {
                    if (!permission.Contains(item))
                    {
                        context.Result = new ForbidResult();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                context.Result = new ForbidResult();
            }
        }
    }

    public class RequiredOneOfPermissionsAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public List<PermissionData> Permissions { get; }

        public RequiredOneOfPermissionsAttribute(params PermissionData[] permissions)
        {
            Permissions = permissions.ToList();
        }

        public  void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
               
                var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId) )
                {
                    context.Result = new ForbidResult();
                    return;
                }
                var permisionUser = Startup.ServiceProvider.GetService(typeof(IPermissionService)) as IPermissionService;
                var permission =  permisionUser.GetPermissionData(Convert.ToInt32(userId));
                if (permission.Contains(PermissionData.ApplicationAdmin))
                    return;
                // check if has one of permission
                foreach (var item in Permissions)
                {
                    if (permission.Contains(item))
                    {
                    
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                var logger = Startup.ServiceProvider.GetService(typeof(Common.ILogger)) as Common.ILogger;
                logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                context.Result = new ForbidResult();
            }
        }
    }
}
