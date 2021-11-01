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
    public class B00ContactController : BaseController
    {
        private readonly IB00ContactService _B00ContactService;

        public B00ContactController(IB00ContactService B00Contact)
        {
            _B00ContactService = B00Contact;
        }
        [HttpPost]
        [Route("insert")]
        [ClaimRequirement(ClaimFunction.CONTACT, ClaimAction.CANREAD)]
        public async Task<IActionResult> Insert([FromBody] B00ContactModel model)
        {
            try
            {
                var response = await _B00ContactService.Insert(model, GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - B00ContactApi," + ex.InnerException.InnerException.Message + "");
            }
        }






        [HttpPut]
        [Route("Update")]
        [ClaimRequirement(ClaimFunction.CONTACT, ClaimAction.CANUPDATE)]
        public async Task<IActionResult> Update([FromBody] B00ContactModel model)
        {
            try
            {
                var responseData = await _B00ContactService.Update(model, GetUserId());
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Update - B00ContactApi," + ex.InnerException.InnerException.Message + "");
            }
        }





        [HttpDelete]
        [Route("delete/{ID}/{code}")]
        [ClaimRequirement(ClaimFunction.CONTACT, ClaimAction.CANDELETE)]
        public async Task<IActionResult> Delete([FromRoute] string code)
        {
            try
            {
                var response = await _B00ContactService.Delete(code, GetUserId());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- B00ContactApi," + ex.InnerException.InnerException.Message + "");

            }
        }







        [HttpGet]
        [Route("get-all")]
        [ClaimRequirement(ClaimFunction.CONTACT, ClaimAction.CANREAD)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _B00ContactService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - B00ContactApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        [HttpPost]
        [Route("Paging")]
        [ClaimRequirement(ClaimFunction.CONTACT, ClaimAction.CANREAD)]
        public async Task<IActionResult> Paging([FromBody] PagingRequestBase pagingRequest)
        {
            try
            {
                var response = await _B00ContactService.Paging(pagingRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAllForPaging - PostApi," + ex.InnerException.InnerException.Message + "");
            }
        }




        [HttpGet]
        [Route("GetById/{ID}/{code}")]
        [ClaimRequirement(ClaimFunction.CONTACT, ClaimAction.CANREAD)]
        public async Task<IActionResult> GetById([FromRoute] string code)
        {
            try
            {
                var responseData = await _B00ContactService.GetById(code);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - B00ContactApi," + ex.InnerException.InnerException.Message + "");
            }
        }
    }
}










