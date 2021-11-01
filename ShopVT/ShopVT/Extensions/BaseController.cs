using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopVT.Extensions
{
    public class BaseController : ControllerBase
    {
        protected int GetUserId()
        {
        
            return  Convert.ToInt32( User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        protected string GetUserCode()
        {
          
            return  User.FindFirst(ClaimTypes.UserData).Value;
        } 
        protected string GetIpAddress()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
    }
}
