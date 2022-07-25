using SimpleChatApp.Infrastructure.Entities;

namespace SimpleChatApp.Infrastructure.Repositories
{
    public interface IChatLogRepository
    {
        public IList<ChatLog> GetLatest(int count = 20);
        void Add(string message, string userId);
    }
}
