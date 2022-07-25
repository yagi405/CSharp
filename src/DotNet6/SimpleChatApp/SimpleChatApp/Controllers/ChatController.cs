using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Models.Services;

namespace SimpleChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public IActionResult Index()
        {
            //ViewBag.Message = "チャットアプリケーションのはじまり";
            return View(_chatService.GetIndexViewModel());
        }
    }
}
