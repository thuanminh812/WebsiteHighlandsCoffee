using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffeeBackend.Models
{
    [Table("TinTuc")]
    public class TinTuc
    {
        [Key]
        public Guid Id { get; set; }
        public string HinhAnh { get; set; }
        public string TieuDe { get; set; }
        public string MotaTinTuc { get; set; }
        public string? LinkUrl { get; set; }
        public DateOnly? NgayTao { get; set; }
        public DateOnly? UpdateTime { get; set; }
        [ForeignKey("DanhMucTinTuc")]
        public Guid TinTucId { get; set; }
        public DanhMucTinTuc DanhMucTinTuc { get; set; }
    }
}
