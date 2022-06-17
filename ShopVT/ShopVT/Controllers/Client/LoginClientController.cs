using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.ExtensionModel;
using Newtonsoft.Json;
using Service.Admin.Service.Interface;
using ShopVT.Extensions;
using ShopVT.Model;
using ShopVT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginClientController : BaseController
    {
        private IConfiguration _config;
        private ILoginAdminService _ser;

        public LoginClientController(IConfiguration config, ILoginAdminService service)
        {
            _config = config;
            _ser = service;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var result = await _ser.Login(request);
                if(result.Code==null ||result.Roles==null)
                {
                    return NotFound();
                }    
                string token = await GenerateJSONWebToken(result);

                return Ok(new { token });
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task<string> GenerateJSONWebToken(IdentityModel identity)
        {

            var json = Task.Run(() =>
                 {
                     var rolesModel = JsonConvert.DeserializeObject<List<RolesModel>>(identity.Roles);
                     List<Roles> listRoles = new List<Roles>();
                     if (!(rolesModel is null))
                     {
                         foreach (var item in rolesModel)
                         {
                             Roles roles = new Roles();
                             roles.Function = item.FunctionCode;
                             roles.CanRead = item.CanRead ? ClaimAction.CANREAD : "";
                             roles.CanCreate = item.CanCreate ? ClaimAction.CANCREATE : "";
                             roles.CanUpdate = item.CanUpdate ? ClaimAction.CANUPDATE : "";
                             roles.CanDelete = item.CanDelete ? ClaimAction.CANDELETE : "";
                             roles.CanReport = item.CanReport ? ClaimAction.CANREPORT : "";
                             listRoles.Add(roles);

                         }
                         return JsonConvert.SerializeObject(listRoles);
                     }
                     return "";
                 });
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>() {
                    new Claim(JwtRegisteredClaimExtension.UserCode, identity.Code),
                    new Claim(JwtRegisteredClaimExtension.EmpCode, identity.EmployeeCode),
                    new Claim(JwtRegisteredClaimExtension.UserId, identity.Id.ToString()),
                    new Claim(JwtRegisteredClaimExtension.FulName, identity.FullName),
                    new Claim(JwtRegisteredClaimNames.NameId,identity.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };
                claims.Add(new Claim(ClaimTypes.Role,await json));
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
