using Microsoft.AspNetCore.Mvc;

namespace SimpleChatApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "チャットアプリケーションのはじまり";
            return View();
        }
    }
}
