using System.Security.Principal;

namespace SimpleChatApp.Models
{
    public interface IAuthenticator
    {
        IIdentity Authenticate(string userId);
    }
}
