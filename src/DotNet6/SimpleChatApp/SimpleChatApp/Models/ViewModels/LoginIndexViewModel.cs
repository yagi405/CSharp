using System.ComponentModel.DataAnnotations;

namespace SimpleChatApp.Models.ViewModels
{
    public record LoginIndexViewModel
    {
        [Display(Name="User ID")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [StringLength(10,ErrorMessage = "{0}は{1}文字以内で入力してください。")]
        public string UserId { get; set; }
    }
}
