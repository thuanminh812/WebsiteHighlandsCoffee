using System.ComponentModel.DataAnnotations;

namespace HighlandsCoffee.DtoModels
{
    public class Register
    {
        [Required(ErrorMessage = "UserName không được trống!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email không được trống!"),EmailAddress]
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        [Required(ErrorMessage = "Password không được trống!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password không được trống!")]
        public string ConfirmPassword { get; set; }
    }
}
