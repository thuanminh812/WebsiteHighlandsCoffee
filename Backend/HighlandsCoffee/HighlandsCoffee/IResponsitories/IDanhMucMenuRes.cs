using HighlandsCoffeeBackend.DtoModels;
using HighlandsCoffeeBackend.Models;

namespace HighlandsCoffeeBackend.IResponsitories
{
    public interface IDanhMucMenuRes
    {
        public Task<List<DanhMucMenuModel>> GetDanhMucMenuAsync();
        public Task<DanhMucMenuModel> GetDanhMucAsyncById(Guid id);
        public Task<Guid> AddDanhMucMenu(DanhMucMenuModel model);
        public Task UpdateDanhMucMenu(Guid id, DanhMucMenuModel model);
        public Task DeleteDanhMucMenu(Guid id);
    }
}
