
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Service.Admin.Service.Interface;
using ShopVT.Extensions;
using ShopVT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class B00FunctionController : BaseController
    {
        private readonly IB00FunctionService _B00FunctionService;

        public B00FunctionController(IB00FunctionService B00Function)
        {
            _B00FunctionService = B00Function;
        }
        [HttpPost]
        [Route("insert")]
        [ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANREAD)]
        public IActionResult Insert([FromBody] B00FunctionModel model)
        {
            try
            {
                var response = _B00FunctionService.Insert(model,GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAllForPaging - PostApi," + ex.InnerException.InnerException.Message + "");
            }
        }



        [HttpPut]
        [Route("Update")]
        [ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANUPDATE)]
        public IActionResult Update([FromBody] B00FunctionModel model)
        {
            try
            {
                var responseData = _B00FunctionService.Update(model);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B00FunctionApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        [HttpDelete]
        [Route("delete/{Code}")]
        [ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANDELETE)]
        public IActionResult Delete([FromRoute] string Code)
        {
            try
            {
                var response = _B00FunctionService.Delete(Code);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: DropDown - B00FunctionApi," + ex.InnerException.InnerException.Message + "");
            }
        }


        [HttpGet]
        [Route("get-all")]
        [ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANREAD)]
        
        public IActionResult GetAll()
        {
            try
            {
                var response = _B00FunctionService.GetAll();
                int j = 0;
               

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - B00FunctionApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        /// <summary> </summary>
        /// <param name="Code">kiểu dữ liệu string</param>
        /// <returns> </returns>

        //[HttpGet]
        //[Route("search")]        [ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANREAD)]
        //public IActionResult Search(string data)
        //{
        //    try
        //    {
        //        var fromData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        //        string _Code = "";
        //        if (fromData.Keys.Contains("Code") && fromData["Code"] != null && fromData["Code"].ToString() != "")
        //        { _Code = Convert.ToString(fromData["Code"].ToString()); }

        //        var response = _B00FunctionService.Search(_Code);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Error at method: Search - B00FunctionApi," + ex.InnerException.InnerException.Message + "");
        //    }
        //}











        [HttpGet]
        [Route("GetById/{Code}")]
        [ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANREAD)]
        public IActionResult GetById([FromRoute] string Code)
        {
            try
            {
                var responseData = _B00FunctionService.GetById(Code);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B00FunctionApi," + ex.InnerException.InnerException.Message + "");
            }
        }
        [HttpGet]
        [Route("GetFunctionTree")]
        public IActionResult GetFunctionTree()
        {
            try
            {
                var responseData = _B00FunctionService.GetFunctionAdminByTree();
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B00FunctionApi," + ex.InnerException.InnerException.Message + "");
            }
        }


    }
}
