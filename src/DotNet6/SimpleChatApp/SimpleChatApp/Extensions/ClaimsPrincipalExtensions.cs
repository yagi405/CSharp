using System.Security.Claims;

namespace SimpleChatApp.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string UserId(this ClaimsPrincipal self) => self.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
