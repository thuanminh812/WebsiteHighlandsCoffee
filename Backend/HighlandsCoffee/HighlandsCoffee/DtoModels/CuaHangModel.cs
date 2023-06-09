namespace HighlandsCoffee.DtoModels
{
    public class CuaHangModel
    {
        public Guid Id { get; set; }
        public string HinhAnh { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string LinkBanDo { get; set; }
        public Guid IdKhuVuc { get; set; }
    }
}
