using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public interface IDonHangRes
    {
        public Task<List<DonHangModel>> GetDonHangAsync();
        public Task<DonHangModel> GetDonHangAsyncById(Guid id);
        public Task<Guid> AddDonHang(DonHangModel model);
        public Task UpdateDonHang(Guid id, DonHangModel model);
        public Task DeleteDonHang(Guid id);
    }
}
