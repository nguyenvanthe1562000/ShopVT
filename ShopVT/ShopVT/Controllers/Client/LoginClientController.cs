using AutoMapper;
using Common;
using Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.ExtensionModel;
using Model.Model;
using Newtonsoft.Json;
using Service.Admin.Service.Interface;
using Service.Command.Interface;
using ShopVT.Extensions;
using ShopVT.Model;
using ShopVT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private string _table = "B10Customer";

        public LoginClientController(ILoginAdminService loginAdminService, IConfiguration configuration, IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor; _config = configuration; _ser = loginAdminService;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
        }
        [HttpPost]
        [Route("Login-Client")]
        public async Task<IActionResult> LoginClient(LoginRequest request)
        {
            try
            {
                var result = await _ser.LoginClient(request);
                if (result.Code == null)
                {
                    return NotFound();
                }
                string token = await GenerateJSONWebTokenClient(result);

                return Ok(new { token });
            }
            catch (Exception)
            {
                throw;
            }

        }
        private async Task<string> GenerateJSONWebTokenClient(IdentityClientModel identity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>() {
                        new Claim(JwtRegisteredClaimExtension.UserCode, identity.Code),
                    new Claim(JwtRegisteredClaimExtension.UserId, identity.Id.ToString()),
                    new Claim(JwtRegisteredClaimExtension.FulName, identity.FullName),
                    new Claim(JwtRegisteredClaimNames.NameId,identity.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddAsync([FromBody] B10CustomerModel addRequest)
        {
            try
            {

                if (string.IsNullOrEmpty(addRequest.Code))
                {
                    addRequest.Code = await GenerateId.NewId(GetCurrentUserId());
                }

                addRequest.BirthDate = DateTime.Now;
                var result = await _edit.Add<B10CustomerModel>(addRequest, _table, "UserName", 1);
                if(result.Messages[0].MessageType == MessageType.Error)
                {
                    return BadRequest(result);
                }    

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { addRequest = addRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }
}
