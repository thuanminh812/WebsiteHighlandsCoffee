using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HighlandsCoffee.Models
{
    [Table("PhanHoi")]
    public class PhanHoi
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string NoiDung { get; set; }
    }
}
