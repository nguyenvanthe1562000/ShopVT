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
        //[HttpGet]
        //public IActionResult actionResult()
        //{
        //    var model = _ctx.B10ProductCategorys.ToList();
        //    return Ok(model);
        //}
    }
}
