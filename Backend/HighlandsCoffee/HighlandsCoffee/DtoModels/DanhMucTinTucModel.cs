namespace HighlandsCoffeeBackend.DtoModels
{
    public class DanhMucTinTucModel
    {
        public Guid TinTucId { get; set; }
        public string TenDanhMuc { get; set; } 
        public string? MotaDanhMuc { get; set; }
    }
}
