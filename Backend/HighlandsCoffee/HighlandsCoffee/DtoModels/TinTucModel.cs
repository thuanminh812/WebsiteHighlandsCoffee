namespace HighlandsCoffee.DtoModels
{
    public class TinTucModel
    {
        public Guid Id { get; set; }
        public Guid TinTucId { get; set; }
        public string HinhAnh { get; set; }
        public string TieuDe { get; set; }
        public string MotaTinTuc { get; set; }
        public string? LinkUrl { get; set; }
        public string? NgayTao { get; set; }

    }
}
