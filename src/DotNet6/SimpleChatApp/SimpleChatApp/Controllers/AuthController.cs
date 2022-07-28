using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Models.Services;
using SimpleChatApp.Models.ViewModels;
using System.Security.Claims;

namespace SimpleChatApp.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginIndexViewModel model)
        {
            throw new NotImplementedException();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var identity = _authService.Authenticate(model);

            if (identity == null)
            {
                return View(model);
            }

            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Chat");
        }
    }
}
