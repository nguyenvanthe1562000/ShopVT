using Common;
using Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Newtonsoft.Json;

using Service.Admin.Service.Interface;
using ShopVT.Extensions;
using ShopVT.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel.catalog.Product;

namespace ShopVT.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = AppRoles.ADMIN)]
    public class B10ProductController : BaseController
    {
        private IStorageService _storageService;
        private readonly IB10ProductService _B10ProductService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public B10ProductController(IB10ProductService B10Product, IStorageService storageService)
        {
            _storageService = storageService;
            _B10ProductService = B10Product;
        }
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromForm] ProductCreateRequest model)
        {
            try
            {
                var response = await _B10ProductService.Insert(model, GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAllForPaging - PostApi," + ex.InnerException.InnerException.Message + "");
            }
        }
        [HttpPost]
        [Route("Paging")]
        public async Task<IActionResult> Paging([FromBody] PagingRequestBase pagingRequest)
        {
            try
            {
                var response = await _B10ProductService.Paging(pagingRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAllForPaging - Product," + ex.InnerException.InnerException.Message + "");
            }
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest model)
        {
            try
            {
                var responseData = await _B10ProductService.Update(model, GetUserId());
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B10ProductApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        [HttpDelete]
        [Route("delete/{code}")]
        public async Task<IActionResult> Delete([FromRoute] string code)
        {
            try
            {
                var response = await _B10ProductService.Delete(code, GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: DropDown - B10ProductApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _B10ProductService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - B10ProductApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        /// <summary> </summary>
        /// <param name="Name">kiểu dữ liệu string</param>
        /// <returns> </returns>

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromRoute] string data)
        {
            try
            {
            //    var fromData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            //    string _Name = "";
            //    if (fromData.Keys.Contains("Name") && fromData["Name"] != null && fromData["Name"].ToString() != "")
            //    { _Name = Convert.ToString(fromData["Name"].ToString()); }

                var response = await _B10ProductService.Search(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Search - B10ProductApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        [HttpGet]
        [Route("GetById/{code}")]
        public async Task<IActionResult> GetById([FromRoute] string code)
        {
            try
            {
                var responseData = await _B10ProductService.GetById(code);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B10ProductApi," + ex.InnerException.InnerException.Message + "");
            }
        }
    }
}







