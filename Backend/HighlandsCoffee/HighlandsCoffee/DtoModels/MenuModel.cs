using HighlandsCoffeeBackend.Models;

namespace HighlandsCoffee.DtoModels
{
    public class MenuModel
    {
        public Guid IdSanPham { get; set; }
        public Guid MenuId { get; set; }
        public string HinhAnh { get; set; }
        public string TenSanPham { get; set; }
        public double GiaBan { get; set; }
        public string MotaSanPham { get; set; }
        public string? LinkUrl { get; set; }


    }
}
