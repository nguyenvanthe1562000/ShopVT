
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ShopVT.EF;
using ShopVT.Extensions;
using ShopVT.Hubs;
using ShopVT.Infrastructure.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Client
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController:BaseController
    {
        private ShopVTDbContext _ctx;
        private IChatRepository _rep;

        public ChatController(ShopVTDbContext ctx,IChatRepository repository)
        {
            _ctx = ctx;
            _rep = repository;
        }
        [HttpPost]
        [Route("CreatePrivateRoom/{name}")]
        public async Task<IActionResult> CreatePrivateRoom(string name)
        {
            var id = await _rep.CreatePrivateRoom(GetCustomerIp(), name);
            return Ok();
        }
        [HttpGet]
        [Route("GetMessage")]
        public async Task<IActionResult> GetMessage()
        {

            var id = await _rep.GetCustomerChat(GetCustomerIp());
            return Ok();
        }
        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(
           int chatId,
           string message,
           string name,
           [FromServices] IHubContext<ChatHub> chat)
        {

            var Message = await _rep.CreateMessageFromCustomer(chatId, message, name, GetCustomerIp());
            await chat.Clients.Group(chatId.ToString())
                .SendAsync("RecieveMessage", new
                {
                    Text = Message.Text,
                    Name = Message.Name,
                    Timestamp = Message.CreatedAt.ToString("dd/MM/yyyy hh:mm:ss")
                });
            return Ok();
        }
    }
}
