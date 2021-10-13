using System.ComponentModel.DataAnnotations;

namespace OnlineStore.View.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}