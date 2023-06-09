using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public  interface IChiTietDonHangRes
    {
        public Task<List<ChiTietDonHangModel>> GetChiTietDonHangAsync();
        public Task<ChiTietDonHangModel> GetChiTietDonHangAsyncById(Guid id);
        public Task<List<ChiTietDonHangModel>> GetChiTietDonHangAsyncByDonHangId(Guid id);
        public Task<Guid> AddChiTietDonHang(ChiTietDonHangModel model);
        public Task UpdateChiTietDonHang(Guid id, ChiTietDonHangModel model);
        public Task DeleteChiTietDonHang(Guid id);
    }
}
