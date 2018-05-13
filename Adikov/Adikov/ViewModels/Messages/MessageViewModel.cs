using System.ComponentModel.DataAnnotations;

namespace Adikov.ViewModels.Messages
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Имя обязательна для заполнения.")]
        public string Username { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон обязателен для заполнения.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+)?[\d\- ()]{7,19}$", ErrorMessage = "Введите корректный телефон.")]
        [MaxLength(20, ErrorMessage = "Введите корректный телефон.")]
        [MinLength(7, ErrorMessage = "Введите корректный телефон.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Сообщение обязателен для заполнения.")]
        public string Content { get; set; }
    }
}