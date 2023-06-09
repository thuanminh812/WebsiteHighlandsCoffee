using Microsoft.AspNetCore.Identity;

namespace HighlandsCoffee.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}
