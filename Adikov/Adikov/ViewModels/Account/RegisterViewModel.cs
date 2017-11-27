using System.ComponentModel.DataAnnotations;

namespace Adikov.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Почта обязательна для заполнения.")]
        [EmailAddress(ErrorMessage = "Неправильный формат почты.")]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [StringLength(100, ErrorMessage = "Пароль должен быть не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}