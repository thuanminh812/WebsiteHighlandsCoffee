using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public interface IPhanHoiRes
    {
        public Task<List<PhanHoiModel>> GetPhanHoiAsync();
        public Task<PhanHoiModel> GetPhanHoiAsyncById(Guid id);
        public Task<Guid> AddPhanHoi(PhanHoiModel model);
        public Task UpdatePhanHoi(Guid id, PhanHoiModel model);
        public Task DeletePhanHoi(Guid id);
    }
}
