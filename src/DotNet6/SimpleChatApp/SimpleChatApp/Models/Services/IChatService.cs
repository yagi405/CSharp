using SimpleChatApp.Models.ViewModels;

namespace SimpleChatApp.Models.Services
{
    public interface IChatService
    {
        ChatIndexViewModel GetIndexViewModel();

        void Post(string message, string userId);

    }
}
