using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffeeBackend.Models
{
    [Table("DanhMucTinTuc")]
    public class DanhMucTinTuc
    {
        [Key]
        public Guid TinTucId { get; set; }
        public string TenDanhMuc { get; set; }
        public string MotaDanhMuc { get; set; }

        public ICollection<TinTuc> TinTucs {get; set;}
    }
}
