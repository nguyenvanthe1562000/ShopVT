using chatapp.database;
using chatapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace chatapp.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly ChatAppDbContext _context;

        public RoomViewComponent(ChatAppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
         
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var chat = _context.ChatUsers.Include(x => x.Chat)
                .Where(x => x.UserId == userid&& x.Chat.Type==ChatType.Room)
                .Select(x => x.Chat)
                .ToList();
            return View(chat);
        }
    }
}
