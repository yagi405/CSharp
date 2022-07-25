namespace SimpleChatApp.Models.ViewModels
{
    public record ChatIndexViewModel(
        string Message,
        IList<ChatIndexViewModel.Detail>? Details
        )
    {
        public ChatIndexViewModel(IList<Detail> details)
            : this("", details) { }

        public ChatIndexViewModel()
            : this("", null) { }

        public record Detail(
            DateTime PostAt,
            string Message,
            string? UserId
        );
    }
}