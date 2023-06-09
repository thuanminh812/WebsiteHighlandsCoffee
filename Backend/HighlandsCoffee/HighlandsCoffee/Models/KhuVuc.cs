using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffee.Models
{
    [Table("KhuVuc")]
    public class KhuVuc
    {
        [Key]
        public Guid IdKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
        public ICollection<CuaHang> CuaHangs { get; set; }
    }
}
