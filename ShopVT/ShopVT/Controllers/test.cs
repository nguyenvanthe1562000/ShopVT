using ShopVT.Infrastructure.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopVT.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private ShopVTDbContext _ctx;
        private IChatRepository _rep;
           






        public testController(ShopVTDbContext ctx, IChatRepository repository)
        {
            _ctx = ctx;
            _rep = repository;
        }
        [HttpGet]
        [Route("gettest")]
        public IActionResult actionResult()
        {
            var model = _ctx.B10Product.ToList();
            var s = model.FirstOrDefault();
            if (model==null )
            {
                return BadRequest("den vc");
            }
            return Ok(model.Count);
        }
    }
}
