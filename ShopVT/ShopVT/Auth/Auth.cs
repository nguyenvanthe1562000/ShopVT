
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        var name = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;//get role of user của token
        
        var name2 = context.HttpContext.User.Claims.ToList();
        var hasClaim = context.HttpContext.User.Claims.Where(c => c.Type == _claim.Type && c.Value == _claim.Value);
        string s = "";
        context.Result = new ForbidResult();
    }
}