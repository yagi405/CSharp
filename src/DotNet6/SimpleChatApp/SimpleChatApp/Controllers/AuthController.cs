using Microsoft.AspNetCore.Mvc;

namespace SimpleChatApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
