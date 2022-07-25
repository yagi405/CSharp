namespace SimpleChatApp.Models.ViewModels
{
    public record ChatIndexViewModel(
        IList<ChatIndexViewModel.Detail> Details
        )
    {
        public record Detail(
            DateTime PostAt,
            string Message
        );
    }
}
