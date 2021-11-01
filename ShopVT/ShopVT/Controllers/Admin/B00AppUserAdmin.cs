using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Newtonsoft.Json;
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
    [Authorize]
    [ApiController]
    public class B00AppUserController : BaseController
    {
        private readonly IB00AppUserService _B00AppUserService;

        public B00AppUserController(IB00AppUserService B00AppUser)
        {
            _B00AppUserService = B00AppUser;
        }
        [HttpPost]
        [Route("insert")]
        [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANCREATE)]
        public async Task<IActionResult> Insert([FromBody] B00AppUserModel model)
        {
            try
            {
                var response = await _B00AppUserService.Insert(model, GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - B00AppUserApi," + ex.InnerException.InnerException.Message + "");
            }
        }






        [HttpPut]
        [Route("Update")]
        [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANUPDATE)]
        public async Task<IActionResult> Update([FromBody] B00AppUserModel model)
        {
            try
            {
                var responseData = await _B00AppUserService.Update(model, GetUserId());
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Update - B00AppUserApi," + ex.InnerException.InnerException.Message + "");
            }
        }





        [HttpDelete]
        [Route("delete/{code}")]
        [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANDELETE)]
        public async Task<IActionResult> Delete([FromRoute] string code)
        {
            try
            {

                var response = await _B00AppUserService.Delete(code, GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- B00AppUserApi," + ex.InnerException.InnerException.Message + "");

            }
        }







        [HttpGet]
        [Route("get-all")]
        [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANREAD)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _B00AppUserService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - B00AppUserApi," + ex.InnerException.InnerException.Message + "");
            }
        }







        [HttpPost]
        [Route("Paging")]
        [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANREAD)]
        public async Task<IActionResult> Paging([FromBody] PagingRequestBase pagingRequest)
        {
            try
            {
                var response = await _B00AppUserService.Paging(pagingRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAllForPaging - PostApi," + ex.InnerException.InnerException.Message + "");
            }
        }




        [HttpGet]
        [Route("GetById/{code}")]
        [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANREAD)]
        public async Task<IActionResult> GetById([FromRoute] string code)
        {
            try
            {
                var responseData = await _B00AppUserService.GetById(code);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B00AppUserApi," + ex.InnerException.InnerException.Message + "");
            }
        }

    }
}











