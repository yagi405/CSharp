using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Principal;

namespace SimpleChatApp.Models
{
    public class Authenticator : IAuthenticator
    {
        public IIdentity Authenticate(string userId)
        {
            //今後の課題で実装

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            return identity;
        }
    }
}
