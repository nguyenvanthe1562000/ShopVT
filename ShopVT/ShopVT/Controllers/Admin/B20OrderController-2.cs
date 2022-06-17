
//using AutoMapper;
//using Common;
//using Common.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Model.Auth;
//using Model.Model;
//using Service.Command.Interface;
//using ShopVT.Auth;
//using ShopVT.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using ViewModel.catalog.Post;
//using ViewModel.catalog.Product;
//using ViewModel.catalog.Slide;
//using ViewModel.Common;
//namespace ShopVT.Controllers.Admin
//{
//    [Route("api/order")]
//    [ApiController]
//    [RequirePermissions(PermissionFunction.Category)]
//    public class B20OrderController : BaseController
//    {
//        private readonly IDataEdtitorService _edit;
//        private readonly IDataExploreService _explore;
//        private IStorageService _storageService;
//        private IMapper _map;
//        private const string USER_CONTENT_FOLDER_NAME = "user-content";
//        //private readonly IDataExploreService _explore;
//        private readonly ILogger _logger;
//        private readonly string _table = "B20Order";

//        public B20OrderController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
//        {
//            _edit = dataEdtitor;
//            _explore = explore;
//            _logger = logger;
//            _storageService = storageService;
//            _map = mapper;
//        }
//        private async Task<string> SaveFile(IFormFile file)
//        {
//            if (file == null) return ""; var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
//            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
//            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
//        }
//        [HttpPost]
//        [Route("add")]
//        [RequiredOneOfPermissions(PermissionData.Create)]
//        public async Task<IActionResult> AddAsync([FromBody] B20OrderModel addRequest)
//        {
//            try
//            {
//                if(string.IsNullOrEmpty(addRequest.code))
//                    addRequest.code=await GenerateId.NewId(GetCurrentUserId());
//                if (string.IsNullOrEmpty(addRequest.CustomerMobile))
//                    return BadRequest(new ResponseMessageDto(MessageType.Error, "số điện thoại không hợp lệ"));
//                //var result = await _edit.AddRangeAsync<B20OrderModel>(addRequest, _table, "OrderCode", addRequest.code,"Code", GetCurrentUserId());
//                var result = await _edit.Add<B20OrderModel>(addRequest, _table, "Code", GetCurrentUserId());
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = addRequest });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }

//        [HttpPut]
//        [Route("update")]
//        [RequiredOneOfPermissions(PermissionData.EditOther, PermissionData.Edit)]
//        public async Task<IActionResult> UpdateAsync([FromBody] B20OrderModel updateRequest)
//        {
//            try
//            {
//                //if (updateRequest.vB20OrderDetail_Json is null) return BadRequest(new ResponseMessageDto(MessageType.Error, "chi tiết chứng từ không hợp lệ"));
//                //if (updateRequest.vB20OrderDetail_Json.Count == 0) return BadRequest(new ResponseMessageDto(MessageType.Error, "tối thiểu 1 dòng chi tiết chứng từ"));
//                //var result = await _edit.UpdateRangeAsync<B20OrderModel>(updateRequest, _table,updateRequest.ID,"OrderCode",updateRequest.code,"",GetCurrentUserId());
//                var result = await _edit.UpdateRangeAsync<B20OrderModel>(updateRequest, _table,updateRequest.ID,"OrderCode",updateRequest.code,"",GetCurrentUserId()); 
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { B20OrderModel = updateRequest });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }
//        [HttpDelete]
//        [RequiredOneOfPermissions(PermissionData.Delete, PermissionData.DeleteOrther)]
//        public async Task<IActionResult> DeleteAsync(int rowid)
//        {
//            try
//            {
//                var result = await _edit.Delete(_table, rowid, GetCurrentUserId());
//                return Ok(result);
//            }

//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { rowid = rowid });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }
//        [HttpPut]
//        [Route("restore")]
//        [RequiredOneOfPermissions(PermissionData.Restore, PermissionData.RestoreOther)]
//        public async Task<IActionResult> RestoreAsync(int rowid)
//        {
//            try
//            {
//                var result = await _edit.Restore(_table, rowid, GetCurrentUserId());
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { rowid = rowid });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }

//        [HttpGet]
//        [Route("{id}")]
//        public async Task<IActionResult> GetById([FromRoute] int id)
//        {
//            try
//            {
//                //lấy 1 bảng và lấy theo 1 cha và nhiều con
//                //var result = await _explore.GetDataByIdMultipleTable<B20OrderModel>(_table, id,"code","ordercode","id",false, GetCurrentUserId());
//                var result = await _explore.GetDataByIdOneTable<B20OrderModel>(_table, id, GetCurrentUserId());
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { id = id });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }
//        [HttpPost]
//        [Route("filter")]
//        public async Task<IActionResult> GetData([FromBody] PagingRequest pagingRequest)
//        {
//            try
//            {
//                // không lấy dữ liệu theo nhóm\
//                // trong 1 danh mục có các cái dữ liệu có chung một mục đích hoặc cùng một loại dữ liệu thì nhóm thành 1 loại để phần biệt với các dữ liệu khác
//                var result = await _explore.GetData<PagedResult<B20OrderModel>, B20OrderModel>(_table,pagingRequest, GetCurrentUserId());
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }
//    }
//}


