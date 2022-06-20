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
    [Route("api/client/home")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private  string _table = "B10ProductCategory";

        public HomeController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetHome()
        {
            try
            {
                _table = "B10HomePage";
                var result = await _explore.Lookup<B10HomePageModel>(_table, "Name", "", 99, "DisplayOrder", false, 1, filterKey: "Show=1");
                for (int i = 0; i < result.Count; i++)
                {
                    _table = "vB10HomePageDetail";
                    var result2 = await _explore.Lookup<vB10HomePageDetailModel>(_table, "stt", result[i].Stt, 99, "id", false, 1);
                    result[i].vB10HomePageDetail_Json = result2.ToList();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }


        [HttpGet]
        [Route("category-product")]
        public async Task<IActionResult> GetDataLookUp1()
        {
            try
            {
                _table = "B10ProductCategory";
                var result = await _explore.Lookup<B10ProductCategoryModel>(_table, "Code", "", 99, "", false,1, filterKey: "IsGroup=0");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("category-post")]
        public async Task<IActionResult> GetDataLookUp2()
        {
            try
            {
                _table = "B10PostCategory";
                var result = await _explore.Lookup<B10PostCategoryModel>(_table, "Code", "", 10, "", false, 1, filterKey: "IsGroup=0");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("slide-header")]
        public async Task<IActionResult> GetDataslide()
        {
            try
            {
                _table = "vB10Slide";
                var result = await _explore.Lookup<vB10SlideModel>(_table, "Code", "", 5, "DisplayOrder", false, 1, filterKey: "Show=1 AND Type =0");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("product-laptop")]
        public async Task<IActionResult> GetDataLookUp4()
        {
            try
            {
                _table = "vB10Product";
                var result = await _explore.Lookup<vB10ProductModel>(_table, "Code", "", 4, "", false, 1, filterKey: "IsGroup=0 AND ProductCategoryCode = 'LAPTOP'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("product-linhkien")]
        public async Task<IActionResult> GetDataLookUp5()
        {
            try
            {
                _table = "vB10Product";
                var result = await _explore.Lookup<vB10ProductModel>(_table, "Code", "", 4, "", false, 1, filterKey: "IsGroup=0 AND ProductCategoryCode = 'LinhKien'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("product-pc")]
        public async Task<IActionResult> GetDataLookUp6()
        {
            try
            {
                _table = "vB10Product";
                var result = await _explore.Lookup<vB10ProductModel>(_table, "Code", "", 4, "", false, 1, filterKey: "IsGroup=0 AND ProductCategoryCode = 'PC'");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("post")]
        public async Task<IActionResult> GetDataLookUp7()
        {
            try
            {
                _table = "B10Post";
                var result = await _explore.Lookup<B10PostModel>(_table, "Code", "", 3, "", false, 1, filterKey: "IsGroup=0 ");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = "" });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }


    }
}


