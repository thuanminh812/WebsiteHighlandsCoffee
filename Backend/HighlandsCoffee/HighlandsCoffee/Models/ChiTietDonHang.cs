using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffeeBackend.Models
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        public Guid Id { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
        public DateOnly UpdateTime { get; set; }
        [ForeignKey("Menu")]
        public Guid IdSanPham { get; set; }
        public Menu Menu { get; set; }
        [ForeignKey("DonHang")]
        public Guid IdDonHang { get; set; }
        public  DonHang DonHang { get; set; }
        
        
    }
}
