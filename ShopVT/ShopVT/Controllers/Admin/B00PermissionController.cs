using AutoMapper;
using Common;
using Common.Helper;
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
using ViewModel.catalog.PermissionViewModel;
using ViewModel.Common;
namespace ShopVT.Controllers.Admin
{
    [Route("api/permission")]
    [ApiController]
    [RequirePermissions(PermissionFunction.System)]
    public class B00PermissionController : BaseController
    {
        private readonly IDataEdtitorService _edit;
        private readonly IDataExploreService _explore;
        private IStorageService _storageService;
        private IDatabaseHelper _dbHelper;
        private IMapper _map;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        //private readonly IDataExploreService _explore;
        private readonly ILogger _logger;
        private readonly string _table = "B00PermissionData";
        public B00PermissionController(IDataEdtitorService dataEdtitor, IDataExploreService explore, ILogger logger, IStorageService storageService, IMapper mapper, IDatabaseHelper databaseHelper)
        {
            _edit = dataEdtitor;
            _explore = explore;
            _logger = logger;
            _storageService = storageService;
            _map = mapper;
            _dbHelper = databaseHelper;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            if (file == null) return ""; var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        [HttpPost]
        [Route("update")]
        [RequiredOneOfPermissions(PermissionData.Create)]
        public async Task<IActionResult> AddAsync([FromForm] PermissionRequest addRequest)
        {
            try
            {
                B00AppUserModel user = new B00AppUserModel();
                List<B00PermissionDataModel> lstData = new List<B00PermissionDataModel>();
                List<B00PermissionFunctionModel> lstFunction = new List<B00PermissionFunctionModel>();
                user = await _explore.GetDataByIdOneTable<B00AppUserModel>("B00AppUser", addRequest.Id, 1);
              
                B00PermissionDataModel b00PermissionDataModel = new B00PermissionDataModel();
                addRequest.PermissionData = JsonConvert.DeserializeObject<List<PermissionDataRequest>>(addRequest.PermissionData1);
                  addRequest.PermissionFunction = JsonConvert.DeserializeObject<PermissionFunctionRequest>(addRequest.PermissionFunction1);
                //return Ok();               
                if (addRequest.PermissionFunction._AccessApplication)
                {
                    {
                        B00PermissionFunctionModel b00PermissionFunctionModel = new B00PermissionFunctionModel();
                        b00PermissionFunctionModel.UserId = user.Id;
                        b00PermissionFunctionModel.IsActive =true;
                        b00PermissionFunctionModel.CommandTypeId =6;
                        b00PermissionFunctionModel.Description = PermissionFunction.AccessApplication.ToString();
                        b00PermissionFunctionModel.Permision = PermissionFunction.AccessApplication;
                        lstFunction.Add(b00PermissionFunctionModel);
                    }
                }
                if (addRequest.PermissionFunction._Category)
                {
                    {
                        B00PermissionFunctionModel b00PermissionFunctionModel = new B00PermissionFunctionModel();
                        b00PermissionFunctionModel.UserId = user.Id;
                        b00PermissionFunctionModel.IsActive = true;
                        b00PermissionFunctionModel.CommandTypeId = 1;
                        b00PermissionFunctionModel.Description = PermissionFunction.Category.ToString();
                        b00PermissionFunctionModel.Permision = PermissionFunction.Category;
                        lstFunction.Add(b00PermissionFunctionModel);
                    }
                }
                if (addRequest.PermissionFunction._Receipt)
                {
                    {
                        B00PermissionFunctionModel b00PermissionFunctionModel = new B00PermissionFunctionModel();
                        b00PermissionFunctionModel.UserId = user.Id;
                        b00PermissionFunctionModel.IsActive = true;
                        b00PermissionFunctionModel.CommandTypeId = 2;
                        b00PermissionFunctionModel.Description = PermissionFunction.Receipt.ToString();
                        b00PermissionFunctionModel.Permision = PermissionFunction.Receipt;
                        lstFunction.Add(b00PermissionFunctionModel);
                    }
                }
                if (addRequest.PermissionFunction._General)
                {
                    {
                        B00PermissionFunctionModel b00PermissionFunctionModel = new B00PermissionFunctionModel();
                        b00PermissionFunctionModel.UserId = user.Id;
                        b00PermissionFunctionModel.IsActive = true;
                        b00PermissionFunctionModel.CommandTypeId = 3;
                        b00PermissionFunctionModel.Description = PermissionFunction.General.ToString();
                        b00PermissionFunctionModel.Permision = PermissionFunction.General;
                        lstFunction.Add(b00PermissionFunctionModel);
                    }
                }
                if (addRequest.PermissionFunction._Report)
                {
                    {
                        B00PermissionFunctionModel b00PermissionFunctionModel = new B00PermissionFunctionModel();
                        b00PermissionFunctionModel.UserId = user.Id;
                        b00PermissionFunctionModel.IsActive = true;
                        b00PermissionFunctionModel.CommandTypeId = 4;
                        b00PermissionFunctionModel.Description = PermissionFunction.Report.ToString();
                        b00PermissionFunctionModel.Permision = PermissionFunction.Report;
                        lstFunction.Add(b00PermissionFunctionModel);
                    }
                }
                if (addRequest.PermissionFunction._System)
                {
                    {
                        B00PermissionFunctionModel b00PermissionFunctionModel = new B00PermissionFunctionModel();
                        b00PermissionFunctionModel.UserId = user.Id;
                        b00PermissionFunctionModel.IsActive = true;
                        b00PermissionFunctionModel.CommandTypeId = 5;
                        b00PermissionFunctionModel.Description = PermissionFunction.System.ToString();
                        b00PermissionFunctionModel.Permision = PermissionFunction.System;
                        lstFunction.Add(b00PermissionFunctionModel);
                    }
                }
                user.B00PermissionFunction_Json = lstFunction;
                foreach (var item in addRequest.PermissionData)
                {

                    if (item._View)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.View.ToString();
                            dataModel.Permission = PermissionData.View;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._ViewOther)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.ViewOther.ToString();
                            dataModel.Permission = PermissionData.ViewOther;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._Create)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.Create.ToString();
                            dataModel.Permission = PermissionData.Create;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._Edit)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.Edit.ToString();
                            dataModel.Permission = PermissionData.Edit;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._EditOther)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.EditOther.ToString();
                            dataModel.Permission = PermissionData.EditOther;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._Delete)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.Delete.ToString();
                            dataModel.Permission = PermissionData.Delete;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._DeleteOrther)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.DeleteOrther.ToString();
                            dataModel.Permission = PermissionData.DeleteOrther;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._Restore)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                             dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.Restore.ToString();
                            dataModel.Permission = PermissionData.Restore;
                            lstData.Add(dataModel);
                        }
                    }
                    if (item._RestoreOther)
                    {
                        {
                            B00PermissionDataModel dataModel = new B00PermissionDataModel();
                            dataModel.CommandId = item.CommandId;
                            dataModel.UserId = user.Id; dataModel.IsActive= true;
                            dataModel.Description = PermissionData.RestoreOther.ToString();
                            dataModel.Permission = PermissionData.RestoreOther;
                            lstData.Add(dataModel);
                        }
                    }
                }
                user.B00PermissionData_Json = lstData;
              var result = await _edit.UpdateRangeAsync<B00AppUserModel>(user, "B00AppUser", user.Id, "UserId", user.Id.ToString(), "", GetCurrentUserId());
                //var result = await _edit.Add<B00AppUserModel>(addRequest, _table, "", GetCurrentUserId());
                //return Ok(result);
                return Ok();
            }


            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = addRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }

        //[HttpPut]
        //[Route("update")]
        //[RequiredOneOfPermissions(PermissionData.EditOther, PermissionData.Edit)]
        //public async Task<IActionResult> UpdateAsync([FromBody] PermissionRequest updateRequest)
        //{
        //    try
        //    {
               
        //          var result = await _edit.Update<B00AppUserModel>(updateRequest, _table, updateRequest.Id, "", GetCurrentUserId());
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = updateRequest });
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
        //    }
        //}

        [HttpPut]
        [Route("update-permission")]
        [RequiredOneOfPermissions(PermissionData.EditOther, PermissionData.Edit)]
        public async Task<IActionResult> UpdatePermissionAsync([FromBody] B00AppUserModel updateRequest)
        {
            try
            {
                var result = await _edit.UpdateRangeAsync<B00AppUserModel>(updateRequest, _table, updateRequest.Id, "UserId", updateRequest.Id.ToString(), "", GetCurrentUserId());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { PostRequest = updateRequest });
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
                string msgError = "";

              var permissionData =   await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_Permission_Data", "@_UserId",
                       id);
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                  return  dt.ConvertTo<vB00PermissionDataModel>().ToList();
                });

                var permissionFunc = await Task.Run(() =>
                {
                    var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "usp_Permission_Function", "@_UserId",
                       id);
                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }
                    return dt.ConvertTo<vB00PermissionFunctionModel>().ToList().FirstOrDefault();
                });
                return Ok(new {data = permissionData, func = permissionFunc});


                ///*var result = await _explore.Lookup<vB00PermissionDataModel>("vB00PermissionData", "UserId", id.ToString(), 9999, "FunctionType", f*/alse, GetCurrentUserId(), isAbsolute: true, "UserId = UserId OR UserId = -1",false);
                //return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { Userid = id });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ""));
            }
        }
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> GetData([FromBody] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _explore.GetData<PagedResult<B00AppUserModel>, B00AppUserModel>(_table, pagingRequest, GetCurrentUserId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Log(LogType.Error, ex.Message, new StackTrace(ex, true).GetFrames().Last(), new { pagingRequest = pagingRequest });
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessageDto(MessageType.Error, ex.Message));
            }
        }
        [HttpGet]
        [Route("group")]
        public async Task<IActionResult> GetGroup()
        {
            try
            {
                var result = await _explore.GetGroup<GroupData>(_table, "FullName", "id", false, GetCurrentUserId());
                if (result.Count() == 0)
                {
                    return Ok(result);
                }
                if (result[0].Children is null)
                {
                    return Ok(result);
                }
                var childsHash = result.ToLookup(cat => cat.ParentId);
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
    }
}


