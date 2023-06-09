using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffeeBackend.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public Guid IdDonHang { get; set; }
        public string UserName { get; set; }
        public string DiaChi { get; set; }
        [MaxLength(10)]
        public string SoDienThoai { get; set; }
        public double? TongTien { get; set; }
        public string? TrangThai { get; set; }
        public DateOnly? NgayMua { get; set; }
        public DateOnly? UpdateTime { get; set; }

        public  ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
