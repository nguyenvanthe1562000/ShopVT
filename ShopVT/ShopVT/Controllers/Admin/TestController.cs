using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Command.Interface;
using ShopVT.Extensions;
using System;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        private readonly IDataEdtitorService _service;
        string table = "product";

        public TestController(IDataEdtitorService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] product model)
        {
            try
            {

                var response = await _service.Add<product>(model, "product", "id",-1);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - product," + ex.InnerException.InnerException.Message + "");
            }
        }
        [HttpPut]
        public async Task<IActionResult> update([FromBody] product model)
        {
            try
            {
                var response = await _service.Update<product>(model, table, model.id, "id", -1);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - product," + ex.InnerException.InnerException.Message + "");
            }
        }
    }
    public class product
    {
        public int id { get; set; }

        public string name { get; set; }
        public long price { get; set; }
        public bool isActive { get; set; }
        public DateTime createdDate { get; set; }

    }

}
