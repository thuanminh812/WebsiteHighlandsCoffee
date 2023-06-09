using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public interface ITinTucRes
    {
        public Task<List<TinTucModel>> GetTinTucAsync();
        public Task<TinTucModel> GetTinTucAsyncById(Guid id);
        public Task<List<TinTucModel>> GetTinTucAsyncByTinTucId(Guid id);
        public Task<Guid> AddTinTuc(TinTucModel model);
        public Task UpdateTinTuc(Guid id, TinTucModel model);
        public Task DeleteTinTuc(Guid id);
    }
}
