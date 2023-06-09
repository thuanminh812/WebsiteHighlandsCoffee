using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffee.Models;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffee.Responsitories
{
    public class CuaHangRes : ICuaHangRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public CuaHangRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddCuaHang(CuaHangModel model)
        {
            var cuaHangNew = _mapper.Map<CuaHang>(model);
            cuaHangNew = new CuaHang
            {
                TenCuaHang = model.TenCuaHang,
                HinhAnh = model.HinhAnh,
                DiaChi = model.DiaChi,
                LinkBanDo = model.LinkBanDo,
                IdKhuVuc = model.IdKhuVuc
            };

            _context.CuaHangs!.Add(cuaHangNew);
            await _context.SaveChangesAsync();
            return cuaHangNew.Id;
        }

        public async Task DeleteCuaHang(Guid id)
        {
            var xoaCuaHang = _context.CuaHangs.FirstOrDefault(x => x.Id == id);
            if (xoaCuaHang != null)
            {
                _context.CuaHangs.Remove(xoaCuaHang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CuaHangModel>> GetCuaHangAsync()
        {
            var cuahang = await _context.CuaHangs.ToListAsync();
            return _mapper.Map<List<CuaHangModel>>(cuahang);
        }

        public async Task<CuaHangModel> GetCuaHangAsyncById(Guid id)
        {
            var cuahang = await _context.CuaHangs!.FindAsync(id);
            return _mapper.Map<CuaHangModel>(cuahang);
        }

        public async Task<List<CuaHangModel>> GetCuaHangAsyncByIdKhuVuc(Guid id)
        {
            var menu = _context.CuaHangs.Where(x => x.IdKhuVuc == id);
            return _mapper.Map<List<CuaHangModel>>(menu);
        }

        public async Task UpdateCuaHang(Guid id, CuaHangModel model)
        {
            var cartUpdate = _mapper.Map<CuaHang>(model);
            if (id! == model.Id)
            {
                cartUpdate = _context.CuaHangs.FirstOrDefault(x => x.Id == id);
                cartUpdate.TenCuaHang = model.TenCuaHang;
                cartUpdate.HinhAnh = model.HinhAnh;
                cartUpdate.IdKhuVuc = model.IdKhuVuc;
                cartUpdate.DiaChi = model.DiaChi;
                cartUpdate.LinkBanDo = model.LinkBanDo;
                _context.CuaHangs!.Update(cartUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
