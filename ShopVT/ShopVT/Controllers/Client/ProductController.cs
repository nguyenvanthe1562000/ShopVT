using AutoMapper;
using Common;
using Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Auth;
using Model.Model;
using Model.Table;
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
using ViewModel.catalog.Product;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/client/product")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "vB10Product";

        public ProductController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
        }
      
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdMulti([FromRoute] int id)
        {

            try
            {
                var result = await _explore.GetDataByIdMultipleTable<vB10ProductModel>(_table, id, "Code", "ProductCode", "id", true, 1);
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
                var result = await _explore.GetData<PagedResult<vB10ProductModel>,vB10ProductModel>(_table,pagingRequest, 1);
                return Ok(result);
            }

            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("look-up")]
        public async Task<IActionResult> GetDataLookUp([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<vB10ProductModel>(_table, "Code,Name", v, 10, "", false, 1, filterKey: "IsGroup=0");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = v });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("related")]
        public async Task<IActionResult> Related([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<vB10ProductModel>(_table, "ProductCategoryCode", v, 3, "", false, 1, filterKey: "IsGroup=0");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = v });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

       
    }
}


