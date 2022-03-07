using Common;
using Common.Interface;
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
    [Route("api/post-category")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Category)]
    public class B10PostCategoryController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B10PostCategory";

        public B10PostCategoryController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService)
        {
            _edit = dataEdtitor;
            _explore= explore;          
            _logger = logger;
            _storageService = storageService;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        //[RequiredOneOfPermissions(PermissionData.Edit, PermissionData.EditOther)]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] B10PostCategoryModel model)
        {
            try
            {
                var result = await _edit.Add<B10PostCategoryModel>(model, _table, "",GetCurrentUserId());
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
                var result = await _edit.Update<B10PostCategoryModel>(model, _table, model.ID, "", 1);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B10PostCategoryModel = model });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int rowid)
        {
            try
            {
                var result = await _edit.Delete(_table, rowid, 1);
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
                var test = await GenerateId.NewId(GetCurrentUserId());
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
        public async Task<IActionResult> AddRangeAsync([FromBody] B10PostCategoryModel model)
        {

            try
            {
                var result = await _edit.AddRangeAsync<B10PostCategoryModel>(model, _table, "code", model.code, "", 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { model = model });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("update-range")]
        public async Task<IActionResult> UpdateRangeAsync([FromBody] B10PostCategoryModel model)
        {

            try
            {
                var result = await _edit.UpdateRangeAsync<B10PostCategoryModel>(model, _table, model.ID, "PostCategoryCode", model.code, "", 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B10PostCategoryModel = model });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            try
            {
                var result = await _explore.GetDataByIdOneTable<B10PostCategoryModel>( _table, id, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { id = id });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("multiple/{id}")]
        public async Task<IActionResult> GetByIdMulti([FromRoute] int id)
        {

            try
            {
                var result = await _explore.GetDataByIdMultipleTable<B10PostCategoryModel>(_table, id,"code","PostCategoryCode","id",true, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { id = id });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> GetData([FromBody] PagingRequest pagingRequest)
        {

            try
            {
                var result = await _explore.GetData<PagedResult<B10PostCategoryModel>>(_table, pagingRequest.PageSize,pagingRequest.PageIndex,true,pagingRequest.FilterColumn,pagingRequest.FilterType, pagingRequest.FilterValue,pagingRequest.OrderBy,pagingRequest.OrderDesc, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("group")]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
                //var result = await _explore.GetGroup<GroupData>(_table, "Description", "id",false, 1);
                var result = await _explore.GetGroup<GroupData>("vB00Command", "Description", "ParentId", false, 1);
                //var childsHash = result.ToLookup(cat => cat.ParentId);
                //foreach (var cat in result)
                //{
                //    cat.Children = childsHash[cat.Id].ToList();
                //}
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last());
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("data-by-group")]
        public async Task<IActionResult> GetDataByGroup([FromRoute] int idGroup,[FromBody] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _explore.GetDataByGroup<PagedResult<B10PostCategoryModel>>(_table, idGroup, pagingRequest.PageSize, pagingRequest.PageIndex, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }
}


