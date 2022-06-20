using AutoMapper;
using Common;
using Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Auth;
using Model.Model;
using Service.Command.Interface;
using ShopVT.Auth;
using ShopVT.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/client/customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private  string _table = "B10Customer";

        public CustomerController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            if (file == null) return ""; var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromForm] B10CustomerModel updateRequest)
        {
            try
            {
                if (updateRequest.ID == 0)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu id không hợp lệ"));
                }
                var result = await _edit.UpdateRangeAsync<B10CustomerModel>(updateRequest, _table, updateRequest.ID, "CustomerCode", updateRequest.Code, "", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = updateRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
      


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] string code)
        {
            try

            {
                var result = await _explore.Lookup<B10CustomerModel>(_table, "", "", 1, "CreatedAt", true, 1, filterKey: $"Code='{code}'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { CustomerCode = code });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("get-address")]
        [Authorize]
        public async Task<IActionResult> GetDataOrder([FromQuery] string code)
        {
            try

            {
                _table = "B10CustomerAddress";
                var result = await _explore.Lookup<B10CustomerAddressModel>(_table, "", "", 100, "CreatedAt", true, 1, filterKey: $"CustomerCode='{code}'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { CustomerCode = code});
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] B10CustomerModel addRequest)
        {
            try
            {

                if (string.IsNullOrEmpty(addRequest.Code))
                {
                    addRequest.Code = await GenerateId.NewId(GetCurrentUserId());
                }
                var result = await _edit.Add<B10CustomerModel>(addRequest, _table, "UserName", 1);
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


