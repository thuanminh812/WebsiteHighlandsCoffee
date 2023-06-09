using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public interface IMenuRes
    {
        public Task<List<MenuModel>> GetMenuAsync();
        public Task<MenuModel> GetMenuAsyncById(Guid id);
        public Task<List<MenuModel>> GetMenuAsyncByMenuId(Guid id);
        public Task<Guid> AddMenu(MenuModel model);
        public Task UpdateMenu(Guid id, MenuModel model);
        public Task DeleteMenu(Guid id);
    }
}
