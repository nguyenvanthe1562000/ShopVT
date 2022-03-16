//using chatapp.database;
//using chatapp.Hubs;
//using chatapp.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace chatapp.Controllers
//{
//    [Authorize]
//    [Route("[controller]")]
//    public class ChatController : Controller
//    {
//        private IHubContext<ChatHub> _chat;

        
      
//        public async Task<IActionResult> SendMessage(int chatId, string message, string roomId, [FromServices] ChatAppDbContext ctx)
//        {
//            var _message = new Message
//            {
//                ChatId = chatId,
//                Text = message,
//                Name = User.Identity.Name,
//                Timestamp = DateTime.Now
//            };
//            await ctx.Messages.AddAsync(_message);
//            await ctx.SaveChangesAsync();

//            await _chat.Clients.Group(roomId).SendAsync("ReceiveMessage", _message);
//            return Ok();
//        }
//    }
//}
