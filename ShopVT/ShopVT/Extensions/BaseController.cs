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
        protected int GetCurrentUserId()
        {
         
            try
            {
                if(User.FindFirst(ClaimTypes.NameIdentifier)==null)
                {
                    return -1;
                }
                var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userid;

            }
            catch (Exception ex)
            {
                return -1;
                throw new Exception(ex.Message.ToString());
            }
           
        }
        protected string GetUserCode()
        {

            return User.FindFirst(JwtRegisteredClaimExtension.UserCode).Value;
        }
        protected string GetIpAddress()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
    }
}
