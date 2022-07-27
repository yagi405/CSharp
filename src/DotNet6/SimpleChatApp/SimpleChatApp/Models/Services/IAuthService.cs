using SimpleChatApp.Models.ViewModels;
using System.Security.Principal;

namespace SimpleChatApp.Models.Services
{
    public interface IAuthService
    {
        IIdentity Authenticate(LoginIndexViewModel model);
    }
}
