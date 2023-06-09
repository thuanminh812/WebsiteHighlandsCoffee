using System.ComponentModel.DataAnnotations;

namespace HighlandsCoffee.DtoModels
{
    public class Login
    {
        [Required(ErrorMessage = "Email không được trống!"),EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password không được trống!")]
        public string Password { get; set; }
    }
}
