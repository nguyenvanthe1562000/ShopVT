﻿//using AutoMapper;
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
//using ViewModel.Common;
//namespace ShopVT.Controllers.Admin
//{
//    [Route("api/app-user")]
//    [ApiController]
//    [RequirePermissions(PermissionFunction.System)]
//    public class B00AppUserController : BaseController
//    {
//        private readonly IDataEdtitorService _edit;
//        private readonly IDataExploreService _explore;
//        private IStorageService _storageService;
//        private IMapper _map;
//        private const string USER_CONTENT_FOLDER_NAME = "user-content";
//        //private readonly IDataExploreService _explore;
//        private readonly ILogger _logger;
//        private readonly string _table = "B00AppUser";
//        public B00AppUserController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
//        {
//            _edit = dataEdtitor;
//            _explore = explore;
//            _logger = logger;
//            _storageService = storageService;
//            _map = mapper;
//        }
//        private async Task<string> SaveFile(IFormFile file)
//        {
//            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
//            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
//            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
//        }
//        [HttpPost]
//        [Route("add")]
//        [RequiredOneOfPermissions(PermissionData.Create)]
//        public async Task<IActionResult> AddAsync([FromForm] B00AppUserModel addRequest)
//        {
//            try
//            {
//                var B00AppUser = _map.Map<B00AppUserModel>(addRequest);
//                B00AppUser.Image = await SaveFile(addRequest.Image);
//                var result = await _edit.Add<B00AppUserModel>(B00AppUser, _table, "", GetCurrentUserId());
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
//        public async Task<IActionResult> UpdateAsync([FromForm] PostRequest updateRequest)
//        {
//            try
//            {
//                if (updateRequest.Id == 0)
//                {
//                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu id không hợp lệ"));
//                }
//                var B00AppUser = _map.Map<B00AppUserModel>(updateRequest);
//                B00AppUser.Image = await SaveFile(updateRequest.Image);
//                var result = await _edit.Update<B00AppUserModel>(B00AppUser, _table, B00AppUser.ID, "", GetCurrentUserId());
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = updateRequest });
//                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
//            }
//        }
//        [HttpDelete]
//        [RequiredOneOfPermissions(PermissionData.Delete, PermissionData.DeleteOrther)]
//        public async Task<IActionResult> DeleteAsync([FromRoute] int rowid)
//        {
//            try
//            {
//                var result = await _edit.Delete(_table, rowid, 1);
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
//                var result = await _edit.Restore(_table, rowid, 1);
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
//                var result = await _explore.GetDataByIdOneTable<B00AppUserModel>(_table, id, 1);
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
//                var result = await _explore.GetData<PagedResult<B00AppUserModel>>(_table, pagingRequest.PageSize, pagingRequest.PageIndex, true, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
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


