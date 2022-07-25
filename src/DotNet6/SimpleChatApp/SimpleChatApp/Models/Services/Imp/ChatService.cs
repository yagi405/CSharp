using SimpleChatApp.Infrastructure.Repositories;
using SimpleChatApp.Models.ViewModels;

namespace SimpleChatApp.Models.Services.Imp
{
    public class ChatService : IChatService
    {
        private readonly IChatLogRepository _chatLogRepository;

        public ChatService(IChatLogRepository chatLogRepository)
        {
            _chatLogRepository = chatLogRepository;
        }

        public ChatIndexViewModel GetIndexViewModel()
        {
            return new ChatIndexViewModel(GetIndexDetails());
        }

        private IList<ChatIndexViewModel.Detail> GetIndexDetails()
        {
            var chatLogs = _chatLogRepository.GetLatest();

            return chatLogs
                .Select(x => new ChatIndexViewModel.Detail(
                x.PostAt,
                x.Message,
                x.UserId
                ))
                .ToList();
        }

        public void Post(string message, string userId)
        {
            _chatLogRepository.Add(message, userId);
        }
    }
}
