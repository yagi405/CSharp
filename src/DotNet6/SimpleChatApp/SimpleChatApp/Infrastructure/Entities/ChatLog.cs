namespace SimpleChatApp.Infrastructure.Entities
{
    public record ChatLog(
        int Id,
        DateTime PostAt,
        string Message,
        string? UserId
    );
}
