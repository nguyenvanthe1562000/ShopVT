using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;

namespace ShopVT.Infrastructure.Respository
{
    public interface IChatRepository
    {
        Task<B20messageModel> CreateMessageFromCustomer(int chatId, string message, string name, string CustomerIp);
        Task<B20messageModel> CreateMessageFromAdmin(int chatId, string message, string name, int userId);
        Task JoinRoom(int userId, int chatId);
        Task<int> CreatePrivateRoom(string CustomerIp, string name);
        Task<IEnumerable<B20messageModel>> GetCustomerChat(string CustomerIp);
        Task<IEnumerable<B20ChatsModel>> GetChats();
        Task<IEnumerable<B20messageModel>> GetMessage(int chatId);
    }
}