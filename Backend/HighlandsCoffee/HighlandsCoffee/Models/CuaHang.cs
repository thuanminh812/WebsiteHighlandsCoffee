using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffee.Models
{
    [Table("CuaHang")]
    public class CuaHang
    {
        [Key]
        public Guid Id { get; set; }
        public string HinhAnh { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string LinkBanDo { get; set; }
        [ForeignKey("KhuVuc")]
        public Guid IdKhuVuc { get; set; }
        public KhuVuc KhuVuc { get; set; }
    }
}
