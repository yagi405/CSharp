using SimpleChatApp.Models.ViewModels;
using System.Security.Principal;

namespace SimpleChatApp.Models.Services.Imp
{
    public class AuthService : IAuthService
    {
        private IAuthenticator _authenticator;

        public AuthService(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public IIdentity Authenticate(LoginIndexViewModel model)
        {
            return _authenticator.Authenticate(model.UserId);
        }
    }
}
