using chatapp.database;
using chatapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatapp.Infrastructure.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatAppDbContext _ctx;
        public ChatRepository(ChatAppDbContext context)
        {
            _ctx = context;
        }
        public async Task<Message> CreateMessage(int chatId, string message, string userId)
        {
            var Message = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = userId,
                Timestamp = DateTime.Now
            };

            _ctx.Messages.Add(Message);
            await _ctx.SaveChangesAsync();
            return Message;
        }

        public async Task<int> CreatePrivateRoom(string rootId, string targetId)
        {
        
            var isNull = _ctx.Chats
              .Include(x => x.Users)     
              .Where(x => x.Type == ChatType.Private && x.Users
                  .Any(y => y.UserId == targetId))
              .ToList();
            if(isNull.Count()>0)
            {
                return isNull[0].Id;
            }    
            var chat = new Chat
            {
                
                Type = ChatType.Private
               
            };

            chat.Users.Add(new ChatUser
            {
                UserId = targetId,
                   Role = UserRole.Guest
            });

            chat.Users.Add(new ChatUser
            {
                UserId = rootId,
                Role=UserRole.Admin

            });

            _ctx.Chats.Add(chat);

            await _ctx.SaveChangesAsync();

            return chat.Id;
        }

        public async Task<int> CreateRoom(string name, string userId)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Room
            };

            chat.Users.Add(new ChatUser
            {
                UserId = userId,
                Role = UserRole.Admin
            });


            _ctx.Chats.Add(chat);

            await _ctx.SaveChangesAsync();
            return chat.Id;
        }

        public Chat GetChat(int id)
        {
            return _ctx.Chats
                 .Include(x => x.Messages)
                 .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Chat> GetChats(string userId)
        {
            return _ctx.Chats
              .Include(x => x.Users)
              .Where(x => x.Type == ChatType.Room && !x.Users
                  .Any(y => y.UserId == userId))
              .ToList();
        }

        public IEnumerable<Chat> GetPrivateChats(string userId)
        {
            return _ctx.Chats
                  .Include(x => x.Users)
                      .ThenInclude(x => x.User)
                  .Where(x => x.Type == ChatType.Private
                      && x.Users
                          .Any(y => y.UserId == userId))
                  .ToList();
        }

        public async Task JoinRoom(int chatId, string userId)
        {
            var chatUser = new ChatUser
            {
                ChatId = chatId,
                UserId = userId,
                Role = UserRole.Member
            };

            _ctx.ChatUsers.Add(chatUser);

            await _ctx.SaveChangesAsync();
        }
    }
}
