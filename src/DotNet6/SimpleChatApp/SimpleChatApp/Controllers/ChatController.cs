using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Extensions;
using SimpleChatApp.Models.Services;
using SimpleChatApp.Models.ViewModels;

namespace SimpleChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_chatService.GetIndexViewModel());
        }

        [HttpPost]
        public IActionResult Index(ChatIndexViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Message))
            {
                //_chatService.Post(model.Message, User.UserId());
                _chatService.Post(model.Message, "h-saito");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
