
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Model.Model;
using ShopVT.EF;
using ShopVT.Extensions;
using ShopVT.Hubs;
using ShopVT.Infrastructure.Respository;
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
    public class ChatController : BaseController
    {
        private ShopVTDbContext _ctx;
        private IChatRepository _rep;

        public ChatController(ShopVTDbContext ctx, IChatRepository repository)
        {
            _ctx = ctx;
            _rep = repository;
        }
        [HttpGet]
        [Route("GetChatRoom")]
        [ClaimRequirement(ClaimFunction.CHAT, ClaimAction.CANREAD)]
        public async Task<IActionResult> GetChatRoom()
        {
            try
            {

                return Ok(await _rep.GetChats());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }
        [HttpPost]
        [Route("JoinChatRoom/{chat}")]
        //      [Authorize(Roles = AppRoles.ADMIN)]
        [ClaimRequirement(ClaimFunction.CHAT, ClaimAction.CANCREATE)]
        public async Task<IActionResult> JoinChatRoom(int chatId)
        {
            try
            {
                await _rep.JoinRoom(GetUserId(), chatId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

        [HttpGet]
        [Route("GetMessage/{id}")]
        [ClaimRequirement(ClaimFunction.CHAT, ClaimAction.CANREAD)]
        public async Task<IActionResult> GetMessage(int chatId)
        {
            try
            {
                return Ok(await _rep.GetMessage(chatId));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }

        }

        public async Task<IActionResult> SendMessage(
         int chatId,
         string message,
         string name,
         [FromServices] IHubContext<ChatHub> chat)
        {

            var Message = await _rep.CreateMessageFromAdmin(chatId, message, name, GetUserId());
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
