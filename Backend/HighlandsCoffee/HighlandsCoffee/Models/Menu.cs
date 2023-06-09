using HighlandsCoffee.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffeeBackend.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public Guid IdSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string TenSanPham { get; set; }
        public double GiaBan { get; set; }
        public string MotaSanPham { get; set; }
        public string? LinkUrl { get; set; }
        public DateOnly? NgayTao { get; set; }
        public DateOnly? UpdateTime { get; set; }
        [ForeignKey("DanhMucMenu")]
        public Guid MenuId { get; set; }
        public DanhMucMenu DanhMucMenu { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
