
//using Common;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using ShopVT;
//using ShopVT.Extensions;
//using ShopVT.Models;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//public class ClaimRequirementAttribute : TypeFilterAttribute
//{
//    public ClaimRequirementAttribute(string function, string action) : base(typeof(ClaimRequirementFilter))
//    {
//        Arguments = new object[] { new Claim(function, action) };
//    }
//}

//public class ClaimRequirementFilter : IAuthorizationFilter
//{
//    readonly Claim _claim;

//    public ClaimRequirementFilter(Claim claim)
//    {
//        _claim = claim;
//    }
//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
       
//        var userCode = context.HttpContext.User.FindFirst(JwtRegisteredClaimExtension.UserCode).Value;
//        if (userCode.Equals("admin"))
//        {
//            return;
//        }
//        else
//        {
//            var getroles = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;//get role of user của token
//            var roles = JsonConvert.DeserializeObject<List<Roles>>(getroles).ToList();
//            if (roles.Exists(c => c.Function == _claim.Type))
//            {
//                if (roles.Exists(c => c.CanCreate == _claim.Value))
//                {
//                    context.Result = new ForbidResult();

//                }
//                else if (roles.Exists(c => c.CanRead == _claim.Value))
//                {
//                    context.Result = new ForbidResult();
//                }
//                else if (roles.Exists(c => c.CanUpdate == _claim.Value))
//                {
//                    context.Result = new ForbidResult();
//                }
//                else if (roles.Exists(c => c.CanDelete == _claim.Value))
//                {
//                    context.Result = new ForbidResult();
//                }
//                else //if (roles.Exists(c => c.CanReport == _claim.Value))
//                {
//                    context.Result = new ForbidResult();
//                }

//            }

//        }    
//    }
//}
////public class RequirePermissionsAttribute : AuthorizeAttribute, IAuthorizationFilter
////{
////    private static bool _requireApplicationAccessPermission = Startup.Configuration.GetValue<bool>("IdentitySettings:RequireApplicationAccessPermission");

////    public List<Permission> Permissions { get; }

////    public RequirePermissionsAttribute(params Permission[] permissions)
////    {
////        Permissions = permissions.ToList();
////    }

////    public void OnAuthorization(AuthorizationFilterContext context)
////    {
////        try
////        {
////            var dbContext = context.HttpContext
////                .RequestServices
////                .GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

////            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
////            var userName = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "user_name")?.Value;
////            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName))
////            {
////                context.Result = new ForbidResult();
////                return;
////            }

////            var user = dbContext.User.FirstOrDefault(u => u.Id == userId);

////            if (!_requireApplicationAccessPermission)
////            {
////                // if not require application access
////                // => every one with valid user account can use this app
////                // => auto add user to application
////                if (user == null)
////                {
////                    user = new User { Id = userId, UserName = userName };
////                    dbContext.User.Add(user);
////                    dbContext.SaveChanges();
////                }
////                //return;
////            }

////            // check restriction
////            foreach (var permission in Permissions)
////            {
////                var hasBeenRestricted = dbContext.UserRestriction.Any(restriction => restriction.UserId == userId && restriction.Permission == permission);
////                if (hasBeenRestricted)
////                {
////                    context.Result = new ForbidResult();
////                    return;
////                }
////            }

////            // get role
////            var roleIds = dbContext.UserRole.Where(ur => ur.UserId == userId).ToList()?.Select(ur => ur.RoleId).ToList();
////            if (roleIds == null || roleIds.Count == 0)
////            {
////                context.Result = new ForbidResult();
////                return;
////            }

////            // check application access permission
////            var hasAccessApplicationPermission = dbContext.RolePermission.Any(rp => roleIds.Contains(rp.RoleId) && rp.Permission == Permission.Access_Application);
////            if (!hasAccessApplicationPermission)
////            {
////                context.Result = new ForbidResult();
////                return;
////            }

////            foreach (var permission in Permissions)
////            {
////                var hasPermission = dbContext.RolePermission.Any(rp => roleIds.Contains(rp.RoleId) && rp.Permission == permission);
////                if (!hasPermission)
////                {
////                    context.Result = new ForbidResult();
////                    return;
////                }
////            }
////        }
////        catch (Exception ex)
////        {
////            var logger = Startup.ServiceProvider.GetService(typeof(ILogger)) as ILogger;
////            logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
////            context.Result = new ForbidResult();
////        }
////    }
////}

////public class RequiredOneOfPermissionsAttribute : AuthorizeAttribute, IAuthorizationFilter
////{
////    public List<Permission> Permissions { get; }

////    public RequiredOneOfPermissionsAttribute(params Permission[] permissions)
////    {
////        Permissions = permissions.ToList();
////    }

////    public void OnAuthorization(AuthorizationFilterContext context)
////    {
////        try
////        {
////            var dbContext = context.HttpContext
////                .RequestServices
////                .GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

////            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
////            if (string.IsNullOrEmpty(userId))
////            {
////                context.Result = new ForbidResult();
////                return;
////            }

////            // get role
////            var roleIds = dbContext.UserRole.Where(ur => ur.UserId == userId).ToList()?.Select(ur => ur.RoleId).ToList();
////            if (roleIds == null || roleIds.Count == 0)
////            {
////                context.Result = new ForbidResult();
////                return;
////            }

////            // check application access permission
////            var hasAccessApplicationPermission = dbContext.RolePermission.Any(rp => roleIds.Contains(rp.RoleId) && rp.Permission == Permission.Access_Application);
////            if (!hasAccessApplicationPermission)
////            {
////                context.Result = new ForbidResult();
////                return;
////            }

////            // check if has one of permission
////            foreach (var permission in Permissions)
////            {
////                var hasPermission = dbContext.RolePermission.Any(rp => roleIds.Contains(rp.RoleId) && rp.Permission == permission);
////                if (hasPermission)
////                {
////                    var hasBeenRestricted = dbContext.UserRestriction.Any(restriction => restriction.UserId == userId && restriction.Permission == permission);
////                    if (!hasBeenRestricted)
////                    {
////                        return;
////                    }
////                }
////            }

////        }
////        catch (Exception ex)
////        {
////            var logger = Startup.ServiceProvider.GetService(typeof(Common.ILogger)) as Common.ILogger;
////            logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
////            context.Result = new ForbidResult();
////        }
////    }
////}