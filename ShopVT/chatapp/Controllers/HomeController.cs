using chatapp.database;
using chatapp.Hubs;
using chatapp.Infrastructure;
using chatapp.Infrastructure.Repository;
using chatapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace chatapp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatRepository _rep;

        public HomeController(ILogger<HomeController> logger, IChatRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult Index()
        {
            var chat = _rep.GetChats(GetUserId());
            return View(chat);
        }
        [HttpGet("{id}")]
        public IActionResult Chat(int id)
        {
            return View(_rep.GetChat(id));
        }
        //public async Task<IActionResult> CreateMessage(int chatId, string message)
        //{
        //    _rep.CreateMessage(chatId, message, GetUserId());
        //    return RedirectToAction("Chat", new { id = chatId });
        //}
        public async Task<IActionResult> SendMessage(int roomId, string message, [FromServices] IHubContext<ChatHub> chat)
        {
            var Message = await _rep.CreateMessage(roomId, message, User.Identity.Name);

            await chat.Clients.Group(roomId.ToString())
                .SendAsync("RecieveMessage", new
                {
                    Text = Message.Text,
                    Name = Message.Name,
                    Timestamp = Message.Timestamp.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            var _chatid = await _rep.CreateRoom(name, GetUserId());

            return RedirectToAction("Chat", "Home", new
            {
                id = _chatid
            });
        }
        public async Task<IActionResult> Find([FromServices] ChatAppDbContext ctx)
        {
            var users = await ctx.Users
                .Where(x => x.Id != User.GetUserId())
                .ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> CreatePrivateRoom(string userId)
        {
            var _chatid = await _rep.CreatePrivateRoom(GetUserId(), userId);
            return RedirectToAction("Chat", new { id = _chatid });
        }
        public IActionResult Private()
        {
            var _chat = _rep.GetPrivateChats(GetUserId());
            return View(_chat);
        }
        public async Task<IActionResult> JoinRoom(int id)
        {

            await _rep.JoinRoom(id, GetUserId());

            return RedirectToAction("Chat", "Home", new { id });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
