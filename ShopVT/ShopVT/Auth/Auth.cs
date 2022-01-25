
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ShopVT.Extensions;
using ShopVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class ClaimRequirementAttribute : TypeFilterAttribute
{
    public ClaimRequirementAttribute(string function, string action) : base(typeof(ClaimRequirementFilter))
    {
        Arguments = new object[] { new Claim(function, action) };
    }
}

public class ClaimRequirementFilter : IAuthorizationFilter
{
    readonly Claim _claim;

    public ClaimRequirementFilter(Claim claim)
    {
        _claim = claim;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
       
        var userCode = context.HttpContext.User.FindFirst(JwtRegisteredClaimExtension.UserCode).Value;
        if (userCode.Equals("admin"))
        {
            return;
        }
        else
        {
            var getroles = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;//get role of user của token
            var roles = JsonConvert.DeserializeObject<List<Roles>>(getroles).ToList();
            if (roles.Exists(c => c.Function == _claim.Type))
            {
                if (roles.Exists(c => c.CanCreate == _claim.Value))
                {
                    context.Result = new ForbidResult();

                }
                else if (roles.Exists(c => c.CanRead == _claim.Value))
                {
                    context.Result = new ForbidResult();
                }
                else if (roles.Exists(c => c.CanUpdate == _claim.Value))
                {
                    context.Result = new ForbidResult();
                }
                else if (roles.Exists(c => c.CanDelete == _claim.Value))
                {
                    context.Result = new ForbidResult();
                }
                else //if (roles.Exists(c => c.CanReport == _claim.Value))
                {
                    context.Result = new ForbidResult();
                }

            }

        }    
    }
}