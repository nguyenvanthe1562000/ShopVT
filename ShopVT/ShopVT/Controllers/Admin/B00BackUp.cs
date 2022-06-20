using AutoMapper;
using Common;
using Common.Helper;
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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel.catalog.Post;
using ViewModel.catalog.Product;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/back-up")]
    [ApiController]
    [RequirePermissions(PermissionFunction.System)]
    public class B00BackupController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B00Backup"; private IDatabaseHelper _dbHelper;

        public B00BackupController(IDataEdtitorService dataEdtitor, IDataExploreService explore, IDatabaseHelper databaseHelper, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper; _dbHelper = databaseHelper;
        }
        private async Task<string> SaveFile(IFormFile file)
        {


            if (file == null) return ""; if (file == null) return ""; var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        [HttpPut]
        [Route("back-up")]
        public async Task<IActionResult> AddAsync()
        {
            try
            {
                string msgError = "";
                var result = await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_BackupData");
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    return "Back-up xong";
                });
         
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = "sao lưu cơ sở dữ liệu" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
       
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> GetData([FromBody] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _explore.GetData<PagedResult<B00BackUpModel>, B00BackUpModel>(_table,pagingRequest, GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {               
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ex.Message));
            }
        }
        
    }
}


