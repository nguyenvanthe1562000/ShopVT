using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Model;
using ShopVT.EF;
using Model.Enums;

namespace ShopVT.Infrastructure.Respository
{
    public class ChatRepository : IChatRepository
    {
        private ShopVTDbContext _ctx;

        public ChatRepository(ShopVTDbContext ctx) => _ctx = ctx;

        public async Task<B20messageModel> CreateMessageFromCustomer(int chatId, string message, string name, string CustomerIp)
        {
            var Message = new B20messageModel
            {
                ChatsId = chatId,
                Text = message,
                Name = name,
                CustomerIp = CustomerIp,
                CreatedAt = DateTime.Now
            };

            _ctx.B20messages.Add(Message);
            await _ctx.SaveChangesAsync();

            return Message;
        }
        public async Task<B20messageModel> CreateMessageFromAdmin(int chatId, string message, string name, int userId)
        {
            var Message = new B20messageModel
            {
                ChatsId = chatId,
                Text = message,
                UserId = userId,
                Name = name,
                CreatedAt = DateTime.Now
            };

            _ctx.B20messages.Add(Message);
            await _ctx.SaveChangesAsync();

            return Message;
        }

        public async Task<int> CreatePrivateRoom(string CustomerIp, string name)
        {
            var chat = new B20ChatsModel
            {
                Name = name,
                Type = ChatType.Private
            };
            _ctx.B20Chatss.Add(chat);
            B20ChatUserModel user = new B20ChatUserModel
            {
                ChatId = chat.ID,
                IpAddress = CustomerIp,
                Role = UserRole.Member
            };
            _ctx.B20ChatUsers.Add(user);
            await _ctx.SaveChangesAsync();

            return chat.ID;
        }
        public async Task<IEnumerable<B20messageModel>> GetCustomerChat(string CustomerIp)
        {
            IEnumerable<B20messageModel> models = new List<B20messageModel>();

            B20ChatUserModel b20ChatUserModel = await _ctx.B20ChatUsers.FindAsync(CustomerIp);        
            models = _ctx.B20messages.Where(x => x.ChatsId == b20ChatUserModel.ChatId).ToList();

            return models;
        }


        public async Task<IEnumerable<B20messageModel>> GetMessage(int chatId)
        {
            IEnumerable<B20messageModel> models = new List<B20messageModel>();
            await Task.Run(() =>
                {
                    models = _ctx.B20messages.Where(x => x.ChatsId == chatId).ToList();
                });
            return models;

        }

        public async Task<IEnumerable<B20ChatsModel>> GetChats()
        {
            IEnumerable<B20ChatsModel> models = new List<B20ChatsModel>();
            await Task.Run(() =>
            {
                models = _ctx.B20Chatss.Where(x => x.Type == ChatType.Private).ToList();
            });
            return models;

        }
        public async Task JoinRoom(int userId, int chatId)
        {
            var exist = _ctx.B20ChatUsers.FirstOrDefault(x => x.ChatId == chatId && x.UserId == userId);
            if (exist == null)
            {
                var chatUser = new B20ChatUserModel
                {
                    ChatId = chatId,
                    UserId = userId,
                    Role = UserRole.Admin
                };
                _ctx.B20ChatUsers.Add(chatUser);
                await _ctx.SaveChangesAsync();
            }

        }
    }
}