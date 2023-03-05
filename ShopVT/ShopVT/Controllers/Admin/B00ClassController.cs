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
    [Route("api/class")]
    [ApiController]
    [Authorize]
    public class B00ClassController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B00Class";
        public B00ClassController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
        }

        [HttpGet]
        [Route("look-up")]
        public async Task<IActionResult> GetDataLookUp([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<B00ClassModel>(_table, "Code", v, 10, "", false, GetCurrentUserId(),filterKey:"ParentCode='SLIDE'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = v });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("look-up-order-status")]
        public async Task<IActionResult> GetDataLookUp1([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<B00ClassModel>(_table, "Code", v, 10, "", false, GetCurrentUserId(), filterKey: "ParentCode='ORDER'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = v });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("look-up-payment-method")]
        public async Task<IActionResult> GetDataLookUp2([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<B00ClassModel>(_table, "Code", v, 10, "", false, GetCurrentUserId(), filterKey: "ParentCode='PAYMENT'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = v });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }

}


