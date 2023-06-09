using HighlandsCoffeeBackend.DtoModels;

namespace HighlandsCoffeeBackend.IResponsitories
{
    public interface IDanhMucTinTucRes
    {
        public Task<List<DanhMucTinTucModel>> GetDanhMucAsync();
        public Task<DanhMucTinTucModel> GetDanhMucAsyncById(Guid id);
        public Task<Guid> AddDanhMuc(DanhMucTinTucModel model);
        public Task UpdateDanhMuc(Guid id, DanhMucTinTucModel model);
        public Task DeleteDanhMuc(Guid id);
    }
}
