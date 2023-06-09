using HighlandsCoffee.DtoModels;

namespace HighlandsCoffee.IResponsitories
{
    public interface ICuaHangRes
    {
        public Task<List<CuaHangModel>> GetCuaHangAsync();
        public Task<CuaHangModel> GetCuaHangAsyncById(Guid id);
        public Task<List<CuaHangModel>> GetCuaHangAsyncByIdKhuVuc(Guid id);
        public Task<Guid> AddCuaHang(CuaHangModel model);
        public Task UpdateCuaHang(Guid id, CuaHangModel model);
        public Task DeleteCuaHang(Guid id);
    }
}
