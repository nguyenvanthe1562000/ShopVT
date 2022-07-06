
using AutoMapper;
using Common;
using Common.Helper;
using Common.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Auth;
using Model.Model;
using Model.View;
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
    [Route("api/report")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Report)]
    public class ReportController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = ""; private IDatabaseHelper _dbHelper;

        public ReportController(IDataEdtitorService dataEdtitor, IDatabaseHelper databaseHelper, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
            _dbHelper = databaseHelper;
        }
      
        [HttpPost]
        [Route("ban-chay")]
        public async Task<IActionResult> ReportBanChay([FromBody] ReportRequest reportRequest)
        {
            try
            {
                string msgError = "";
                   var resutl = await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_banchay", "@_docdate1",
                       reportRequest.DocDate1, "@_docdate2",
                       reportRequest.DocDate2, "@_itemCode",
                       reportRequest.ItemCode);
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    return dt.ConvertTo<usp_banchay>().ToList();
                });
                return Ok(resutl);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { reportRequest = reportRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("ton")]
        public async Task<IActionResult> ReportTon([FromBody] ReportRequest reportRequest)
        {
            try
            {
                string msgError = "";
                var resutl = await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_ton", "@_itemCode",
                       reportRequest.ItemCode);
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    return dt.ConvertTo<usp_ton>().ToList();
                });
                return Ok(resutl);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { reportRequest = reportRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("nhap")]
        public async Task<IActionResult> ReportNhap([FromBody] ReportRequest reportRequest)
        {
            try
            {
                string msgError = "";
             
                var resutl = await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_nhap", "@_docdate1",
                       reportRequest.DocDate1, "@_docdate2",
                       reportRequest.DocDate2, "@_itemCode",
                       reportRequest.ItemCode);
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    return dt.ConvertTo<usp_Nhap>().ToList();
                });
                return Ok(resutl);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { reportRequest = reportRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
    }
}


