

using Common;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Auth;
using Model.Model;
using Service.Command.Interface;
using ShopVT.Auth;
using ShopVT.Extensions;
using ShopVT.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Admin
{
    [Route("api/post-category")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Category)]
    public class B10PostCategoryController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B10PostCategory";

        public B10PostCategoryController(IDataEdtitorService dataEdtitor, ILogger logger)
        {
            _edit = dataEdtitor;
            //_explore = dataExplore;
            _logger = logger;
        }

        //[RequiredOneOfPermissions(PermissionData.Edit, PermissionData.EditOther)]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] B10PostCategoryModel model)
        {
            try
            {
                var result= await  _edit.Add<B10PostCategoryModel>(model, _table, "", 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B10PostCategoryModel = model });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] B10PostCategoryModel model)
        {
            try
            {
                var result = await _edit.Update<B10PostCategoryModel>(model, _table,model.ID, "", 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B10PostCategoryModel = model });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync( int rowid)
        {
            try
            {
                var result = await _edit.Delete( _table, rowid, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { rowid = rowid });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPut]
        [Route("restore")]
        [RequiredOneOfPermissions(PermissionData.Restore, PermissionData.RestoreOther)]
        public async Task<IActionResult> RestoreAsync(int rowid)
        {
           
            try
            {
                var test = await GenerateId.NewId(GetUserId());
                var result = await _edit.Restore(_table, rowid, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { rowid = rowid });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("add-range")]
        public async Task<IActionResult> AddRangeAsync(int rowid)
        {

            try
            {
                  var result = await _edit.Restore(_table, rowid, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { rowid = rowid });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }
}


