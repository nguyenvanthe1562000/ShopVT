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
    [Route("api/product")]
    [ApiController]
    [RequirePermissions(PermissionFunction.Category)]
    public class B10ProductController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "vB10Product";

        public B10ProductController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper)
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
        public async Task<IActionResult> AddAsync([FromForm] ProductCreateRequest addRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(addRequest.Code))
                {
                    addRequest.Code = await GenerateId.NewId(GetCurrentUserId());
                }

                var b10product = _map.Map<vB10ProductModel>(addRequest);
                b10product.B10ProductInformation_Json = JsonConvert.DeserializeObject<List<B10ProductInformationModel>>(addRequest.ProductInformation_Json);
                List<B10ProductImgModel> b10ProductImgs = new List<B10ProductImgModel>();
                B10ProductImgModel productImgModel = new B10ProductImgModel()
                {
                    ProductCode = addRequest.Code,
                    Caption = b10product.Alias,
                    ImageDefault = true,
                    ImagePath = await SaveFile(addRequest.ImageDefault)
                };
                b10ProductImgs.Add(productImgModel);
                if(addRequest.ThumbnailImage !=null)
                {
                    foreach (var item in addRequest.ThumbnailImage)
                    {
                        B10ProductImgModel productImg = new B10ProductImgModel()
                        {
                            ProductCode = addRequest.Code,
                            Caption = b10product.Alias,
                            ImageDefault = false,
                            ImagePath = await SaveFile(item)
                        };
                        b10ProductImgs.Add(productImg);
                    }
                }
                b10product.B10ProductImg_Json = b10ProductImgs;
                 var result = await _edit.AddRangeAsync<vB10ProductModel>(b10product, _table, "ProductCode", b10product.Code,"Code", GetCurrentUserId());
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
        [RequiredOneOfPermissions(PermissionData.EditOther,PermissionData.Edit)]
        public async Task<IActionResult> UpdateAsync([FromForm] ProductUpdateRequest updateRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(updateRequest.Code))
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu code không hợp lệ"));
                }
                if (updateRequest.ID ==0)
                {
                    return BadRequest(new ResponseMessageDto(MessageType.Error, "dữ liệu id không hợp lệ"));
                }
                var b10product = _map.Map<vB10ProductModel>(updateRequest);
                b10product.B10ProductInformation_Json = JsonConvert.DeserializeObject<List<B10ProductInformationModel>>(updateRequest.ProductInformation_Json);
                List<B10ProductImgModel> b10ProductImgs = new List<B10ProductImgModel>();

                B10ProductImgModel productImgModel = new B10ProductImgModel()
                {
                    ProductCode = updateRequest.Code,
                    Caption = b10product.Alias,
                    ImageDefault = true,
                    ImagePath = await SaveFile(updateRequest.ImageDefault)
                };
                b10ProductImgs.Add(productImgModel);
                if (updateRequest.ThumbnailImage != null)
                {
                    foreach (var item in updateRequest.ThumbnailImage)
                    {
                        B10ProductImgModel productImg = new B10ProductImgModel()
                        {
                            ProductCode = updateRequest.Code,
                            Caption = b10product.Alias,
                            ImageDefault = false,
                            ImglengthSize = item.Length,
                            ImagePath = await SaveFile(item)
                        };
                        b10ProductImgs.Add(productImg);
                    }
                }
                b10product.B10ProductImg_Json = b10ProductImgs;
                var result = await _edit.UpdateRangeAsync<vB10ProductModel>(b10product, _table, b10product.ID, "ProductCode", b10product.Code, "", GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)    
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { ProductUpdateRequest = updateRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPut]
        [Route("tranfer")]
        [RequiredOneOfPermissions(PermissionData.EditOther, PermissionData.Edit)]
        public async Task<IActionResult> UpdateAsync2([FromBody] ProductUpdateRequest updateRequest)
        {
            try
            {
               
                var b10product = _map.Map<vB10ProductModel>(updateRequest);
                var result = await _edit.Update<vB10ProductModel>(b10product, _table, b10product.ID, "", GetCurrentUserId());
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
        [Route("group")]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
                var result = await _explore.GetGroup<GroupData>(_table, "Name", "id", false, 1);
                var childsHash = result.ToLookup(cat => cat.ParentId);
                if (result.Count() == 0)
                {
                    return Ok(result);
                }
                if (result[0].Children is null)
                {
                    return Ok(result);
                }
               
                foreach (var cat in result)
                {
                    cat.Children = childsHash[cat.Data].ToList();
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
                var result = await _explore.GetDataByGroup<PagedResult<B10PostCategoryModel>, B10PostCategoryModel>(_table, idGroup, pagingRequest.PageSize, pagingRequest.PageIndex, pagingRequest.FilterColumn, pagingRequest.FilterType, pagingRequest.FilterValue, pagingRequest.OrderBy, pagingRequest.OrderDesc, 1);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        [HttpGet]
        [Route("look-up-product-info")]
        public async Task<IActionResult> GetDataCategoryInfLookUp([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<B10ProductCategoryInfModel>("B10ProductCategoryInf", "productcategorycode", v, 10, "", false, GetCurrentUserId(),true,"");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { loolupData = v });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpGet]
        [Route("look-up")]
        public async Task<IActionResult> GetDataLookUp([FromQuery] string v)
        {
            try
            {
                var result = await _explore.Lookup<vB10ProductModel>(_table, "Code", v, 10, "", false, GetCurrentUserId(), filterKey: "IsGroup=0");
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


