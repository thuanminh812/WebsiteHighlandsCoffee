using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public interface IKhuVucRes
    {
        public Task<List<KhuVucModel>> GetKhuVucAsync();
        public Task<KhuVucModel> GetKhuVucAsyncById(Guid id);
        public Task<Guid> AddKhuVuc(KhuVucModel model);
        public Task UpdateKhuVuc(Guid id, KhuVucModel model);
        public Task DeleteKhuVuc(Guid id);
    }
}
