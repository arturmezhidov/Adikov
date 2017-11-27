using System.ComponentModel.DataAnnotations;

namespace Adikov.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Почта обязательна для заполнения.")]
        [Display(Name = "Почта")]
        [EmailAddress(ErrorMessage = "Неправильный формат почты.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}