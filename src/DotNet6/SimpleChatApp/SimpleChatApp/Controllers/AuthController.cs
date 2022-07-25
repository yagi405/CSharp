using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SimpleChatApp.Models.ViewModels;

namespace SimpleChatApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index","Chat");
        }
    }
}
