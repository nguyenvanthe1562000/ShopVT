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
using ViewModel.catalog.Product;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/product-category")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Category)]
    public class B10ProductCategoryController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B10ProductCategory";

        public B10ProductCategoryController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
        }
        [HttpPost]
        [Route("add")]
        [RequiredOneOfPermissions(PermissionData.Create)]
        public async Task<IActionResult> AddAsync([FromBody] B10ProductCategoryModel addRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(addRequest.Code))
                {
                    addRequest.Code = await GenerateId.NewId(GetCurrentUserId());
                }
                var result = await _edit.AddRangeAsync<B10ProductCategoryModel>(addRequest, _table, "ProductCategoryCode",addRequest.Code,"Code", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { ProductCreateRequest = addRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPut]
        [Route("update")]
        [RequiredOneOfPermissions(PermissionData.EditOther, PermissionData.Edit)]
        public async Task<IActionResult> UpdateAsync([FromBody] B10ProductCategoryModel updateRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(updateRequest.Code))
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu code không hợp lệ"));
                }
                if (updateRequest.Id == 0)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu id không hợp lệ"));
                }
                var result = await _edit.UpdateRangeAsync<B10ProductCategoryModel>(updateRequest, _table, updateRequest.Id, "ProductCategoryCode",updateRequest.Code,"", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { ProductUpdateRequest = updateRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpDelete]
        [RequiredOneOfPermissions(PermissionData.Delete, PermissionData.DeleteOrther)]
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
        [Route("filter")]
        public async Task<IActionResult> GetData([FromBody] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _explore.GetData<PagedResult<B10ProductCategoryModel>, B10ProductCategoryModel>(_table, pagingRequest.PageSize, pagingRequest.PageIndex, true, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }



        [HttpPost]
        [Route("group")]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
                var result = await _explore.GetGroup<GroupData>(_table, "name", "id", false, 1);
                var childsHash = result.ToLookup(cat => cat.ParentId);
                foreach (var cat in result)
                {
                    cat.Children = childsHash[cat.Id].ToList();
                }
                return Ok(childsHash);
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
                var result = await _explore.GetDataByGroup<PagedResult<B10PostCategoryModel>, B10PostCategoryModel>(_table, idGroup, pagingRequest.PageSize, pagingRequest.PageIndex, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
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


