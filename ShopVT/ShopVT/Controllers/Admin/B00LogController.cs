using API.Dto.Admin.ServiceDtos;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Auth;
using ShopVT.Auth;
using System;
using System.Diagnostics;
using System.Linq;

namespace API.Controllers.Admin.Service
{
    [Route("api/log")]
    [ApiController]
    [RequirePermissions(PermissionFunction.System)]
    public class LogController : ControllerBase
    {
        private ILogger _logger;

        public LogController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetAsync()
        {
            try
            {
                FilterLogDto filterDto=new FilterLogDto();
                var logs = _logger.QueryLog(filterDto.Type, filterDto.LogTimeFrom, filterDto.LogTimeTo, filterDto.FileName, filterDto.ClassName, filterDto.MethodName, filterDto.LineNumber);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("archive-log-file")]
        public IActionResult Archive()
        {
            try
            {
                var isSuccess = _logger.ArchiveLogFile();

                if (isSuccess)
                {
                    return Ok(new ResponseMessageDto(MessageType.Success, null));
                }
                else
                {
                    return Ok(new ResponseMessageDto(MessageType.Error, "Không lưu được file."));
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, (new StackTrace(ex, true)).GetFrames().Last());
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }
}
