
using AutoMapper;
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel.catalog.Post;
using ViewModel.catalog.Product;
using ViewModel.catalog.Slide;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/supplier")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Category)]
    public class B10SupplierController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B10Supplier";

        public B10SupplierController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        [HttpPost]
        [Route("add")]
        [RequiredOneOfPermissions(PermissionData.Create)]
        public async Task<IActionResult> AddAsync([FromBody] B10SupplierModel addRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(addRequest.Code)) return BadRequest(new ResponseMessageDto(MessageType.Error, "Mã không hợp lệ"));
                if (string.IsNullOrEmpty(addRequest.Name)) return BadRequest(new ResponseMessageDto(MessageType.Error, "Tên không hợp lệ"));
                var result = await _edit.Add<B10SupplierModel>(addRequest, _table, "", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = addRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("add-group")]
        [RequiredOneOfPermissions(PermissionData.Create)]
        public async Task<IActionResult> AddGroupAsync([FromBody] B10SupplierModel addRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(addRequest.Code)) return BadRequest(new ResponseMessageDto(MessageType.Error, "Mã không hợp lệ"));
                if (string.IsNullOrEmpty(addRequest.Name)) return BadRequest(new ResponseMessageDto(MessageType.Error, "Tên không hợp lệ"));
                addRequest.IsGroup = true;
                var result = await _edit.Add<B10SupplierModel>(addRequest, _table, "", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = addRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPut]
        [Route("update")]
        [RequiredOneOfPermissions(PermissionData.EditOther, PermissionData.Edit)]
        public async Task<IActionResult> UpdateAsync([FromBody] B10SupplierModel updateRequest)
        {
            try
            {
                if (updateRequest.Id == 0)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu id không hợp lệ"));
                }
                if (string.IsNullOrEmpty(updateRequest.Code)) return BadRequest(new ResponseMessageDto(MessageType.Error, "Mã không hợp lệ"));
                if (string.IsNullOrEmpty(updateRequest.Name)) return BadRequest(new ResponseMessageDto(MessageType.Error, "Tên không hợp lệ"));

                var result = await _edit.Update<B10SupplierModel>(updateRequest, _table, updateRequest.Id, "", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B10SupplierModel = updateRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpDelete]
        [RequiredOneOfPermissions(PermissionData.Delete, PermissionData.DeleteOrther)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int rowid)
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
                var result = await _edit.Restore(_table, rowid, 1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { rowid = rowid });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var result = await _explore.GetDataByIdOneTable<B10SupplierModel>(_table, id, 1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { id = id });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("group")]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
                var result = await _explore.GetGroup<GroupData>(_table, "Name", "id", false, 1);
                var childsHash = result.ToLookup(cat => cat.ParentId);
                foreach (var cat in result)
                {
                    cat.Children = childsHash[cat.Id].ToList();
                }
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
        public async Task<IActionResult> GetDataByGroup([FromRoute] int idGroup, [FromBody] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _explore.GetDataByGroup<PagedResult<B10SupplierModel>, B10SupplierModel>(_table, idGroup, pagingRequest.PageSize, pagingRequest.PageIndex, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> GetData([FromBody] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _explore.GetData<PagedResult<B10SupplierModel>, B10SupplierModel>(_table, pagingRequest.PageSize, pagingRequest.PageIndex, true, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
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


