using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffeeBackend.Models
{
    [Table("DanhMucMenu")]
    public class DanhMucMenu
    {
        [Key]
        public Guid MenuId { get; set; }
        public string TenDanhMuc { get; set; }
        public string MotaDanhMuc { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
