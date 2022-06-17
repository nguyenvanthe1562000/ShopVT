
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
    [Route("api/client/order")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "vB20Order";

        public OrderController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
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
        public async Task<IActionResult> AddAsync([FromBody] OrderRequest addRequest)
        {
            try
            {
                if (addRequest.vB20OrderDetail is null) return BadRequest(new ResponseMessageDto(MessageType.Error, "chi tiết chứng từ không hợp lệ"));
                
                if (addRequest.vB20OrderDetail=="") return BadRequest(new ResponseMessageDto(MessageType.Error, "tối thiểu 1 dòng chi tiết chứng từ"));
                addRequest.Stt=await GenerateId.NewId(1);
                addRequest.code="HD";

                var add = _map.Map<vB20OrderModel>(addRequest);

                add.vB20OrderDetail_Json = JsonConvert.DeserializeObject<List<vB20OrderDetailModel>>(addRequest.vB20OrderDetail);
                add.Amount = add.vB20OrderDetail_Json.Sum(x => x.Amount);
                var result = await _edit.AddRangeAsync<vB20OrderModel>(add, _table,"Stt",addRequest.Stt,"",1);
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
        public async Task<IActionResult> UpdateAsync([FromBody] OrderRequest updateRequest)
        {
            try
            {
                if (updateRequest.vB20OrderDetail is null) return BadRequest(new ResponseMessageDto(MessageType.Error, "chi tiết chứng từ không hợp lệ"));

                if (updateRequest.vB20OrderDetail == "") return BadRequest(new ResponseMessageDto(MessageType.Error, "tối thiểu 1 dòng chi tiết chứng từ"));
                var update = _map.Map<vB20OrderModel>(updateRequest);
                update.vB20OrderDetail_Json = JsonConvert.DeserializeObject<List<vB20OrderDetailModel>>(updateRequest.vB20OrderDetail);
                update.Amount = update.vB20OrderDetail_Json.Sum(x => x.Amount);
                update.code = "HD";
                var result = await _edit.UpdateRangeAsync<vB20OrderModel>(update, _table, updateRequest.ID, "Stt",updateRequest.Stt,"", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B20OrderModel = updateRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var result = await _explore.GetDataByIdMultipleTable<vB20OrderModel>(_table, id,"Stt","Stt","id",false, GetCurrentUserId());
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
                var result = await _explore.GetData<PagedResult<vB20OrderModel>, vB20OrderModel>(_table,pagingRequest, GetCurrentUserId());
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


