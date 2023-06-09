namespace HighlandsCoffee.DtoModels
{
    public class ChiTietDonHangModel
    {
        public Guid Id { get; set; }
        public Guid IdSanPham { get; set; }
        public Guid IdDonHang { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
    }
}
