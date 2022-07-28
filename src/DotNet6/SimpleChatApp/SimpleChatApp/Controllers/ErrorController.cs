using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Models.ViewModels;

namespace SimpleChatApp.Controllers
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken]
    public class ErrorController : Controller
    {
        public IActionResult Index(int id = 0)
        {
            switch (id)
            {
                case 404:
                    //例えば、404であれば
                    //静的なページやビューにリダイレクト
                    return RedirectToAction(nameof(PageNotFound));
            }
            //内部エラーの場合はエラー情報を取得
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var model = new ErrorIndexViewModel(id, exception);
            //ステータスコードと例外情報を使用してエラーを表示
            return View(model);
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }

}
