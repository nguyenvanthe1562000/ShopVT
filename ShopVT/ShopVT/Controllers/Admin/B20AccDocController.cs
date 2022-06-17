
using AutoMapper;
using Common;
using Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Auth;
using Model.Model;
using Newtonsoft.Json;
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
using ViewModel.catalog.AccDoc;
using ViewModel.catalog.Post;
using ViewModel.catalog.Product;
using ViewModel.catalog.Slide;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/accdoc-product")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Category)]
    public class B20AccDocProductController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B20AccDocProduct";

        public B20AccDocProductController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
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
        [HttpPost]
        [Route("add")]
        [RequiredOneOfPermissions(PermissionData.Create)]
        public async Task<IActionResult> AddAsync([FromBody] AccDocProductRequest addRequest)
        {
            try
            {
                if (addRequest.vB20AccDocProductDetail is null) return BadRequest(new ResponseMessageDto(MessageType.Error, "chi tiết chứng từ không hợp lệ"));
                
                if (addRequest.vB20AccDocProductDetail=="") return BadRequest(new ResponseMessageDto(MessageType.Error, "tối thiểu 1 dòng chi tiết chứng từ"));
                addRequest.Stt=await GenerateId.NewId(GetCurrentUserId());

                var add = _map.Map<B20AccDocProductModel>(addRequest);
                add.DocCode = "NM";
                add.vB20AccDocProductDetail_Json = JsonConvert.DeserializeObject<List<vB20AccDocProductDetailModel>>(addRequest.vB20AccDocProductDetail);
                add.Amount = add.vB20AccDocProductDetail_Json.Sum(x => x.Amount);
                var result = await _edit.AddRangeAsync<B20AccDocProductModel>(add, _table,"Stt",addRequest.Stt,"", GetCurrentUserId());
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
        public async Task<IActionResult> UpdateAsync([FromBody] AccDocProductRequest updateRequest)
        {
            try
            {
                if (updateRequest.vB20AccDocProductDetail is null) return BadRequest(new ResponseMessageDto(MessageType.Error, "chi tiết chứng từ không hợp lệ"));

                if (updateRequest.vB20AccDocProductDetail == "") return BadRequest(new ResponseMessageDto(MessageType.Error, "tối thiểu 1 dòng chi tiết chứng từ"));
                var update = _map.Map<B20AccDocProductModel>(updateRequest);
                update.vB20AccDocProductDetail_Json = JsonConvert.DeserializeObject<List<vB20AccDocProductDetailModel>>(updateRequest.vB20AccDocProductDetail);
                update.Amount = update.vB20AccDocProductDetail_Json.Sum(x => x.Amount);
                update.DocCode = "NM";
                var result = await _edit.UpdateRangeAsync<B20AccDocProductModel>(update, _table, updateRequest.Id, "Stt",updateRequest.Stt,"", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B20AccDocProductModel = updateRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpDelete]
        [RequiredOneOfPermissions(PermissionData.Delete, PermissionData.DeleteOrther)]
        public async Task<IActionResult> DeleteAsync(int rowid)
        {
            try
            {
                var result = await _edit.Delete(_table, rowid, GetCurrentUserId());
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
                var result = await _edit.Restore(_table, rowid, GetCurrentUserId());
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
                var result = await _explore.GetDataByIdMultipleTable<B20AccDocProductModel>(_table, id,"Stt","Stt","id",false, GetCurrentUserId());
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
                var result = await _explore.GetData<PagedResult<B20AccDocProductModel>, B20AccDocProductModel>(_table,pagingRequest, GetCurrentUserId());
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
              
                return Ok();
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last());
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }
}


