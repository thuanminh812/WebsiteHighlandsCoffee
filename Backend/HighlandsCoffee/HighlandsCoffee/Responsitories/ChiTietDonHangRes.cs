using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffee.Responsitories
{
    public class ChiTietDonHangRes : IChiTietDonHangRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public ChiTietDonHangRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddChiTietDonHang(ChiTietDonHangModel model)
        {
            var donhangNew = _mapper.Map<ChiTietDonHang>(model);
            donhangNew =  new ChiTietDonHang
                {
                    Id = model.Id,
                    IdDonHang = model.IdDonHang,
                    IdSanPham = model.IdSanPham,
                    TenSanPham = model.TenSanPham,
                    SoLuong = model.SoLuong,
                    GiaBan = model.GiaBan,
                    UpdateTime = DateOnly.FromDateTime(DateTime.Now)
            };
            
            _context.ChiTietDonHangs!.Add(donhangNew);
            await _context.SaveChangesAsync();
            return donhangNew.Id;
        }

        public async Task DeleteChiTietDonHang(Guid id)
        {
            var xoaDonHang = _context.ChiTietDonHangs!.SingleOrDefault(x => x.Id == id);
            if (xoaDonHang != null)
            {
                _context.ChiTietDonHangs.Remove(xoaDonHang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ChiTietDonHangModel>> GetChiTietDonHangAsync()
        {
            var menus = await _context.ChiTietDonHangs.ToListAsync();
            return _mapper.Map<List<ChiTietDonHangModel>>(menus);
        }

        public async Task<List<ChiTietDonHangModel>> GetChiTietDonHangAsyncByDonHangId(Guid id)
        {
            var menu = _context.ChiTietDonHangs.Where(x => x.IdDonHang == id);
            return _mapper.Map<List<ChiTietDonHangModel>>(menu);
        }

        public async Task<ChiTietDonHangModel> GetChiTietDonHangAsyncById(Guid id)
        {
            var menu = await _context.ChiTietDonHangs!.FindAsync(id);
            return _mapper.Map<ChiTietDonHangModel>(menu);
        }

        public async Task UpdateChiTietDonHang(Guid id, ChiTietDonHangModel model)
        {
            var donhangUpdate = _mapper.Map<ChiTietDonHang>(model);
            if (id! == model.Id)
            {
                donhangUpdate = _context.ChiTietDonHangs.FirstOrDefault(x => x.Id == id);
                donhangUpdate.IdDonHang = model.IdDonHang;
                donhangUpdate.IdSanPham = model.IdSanPham;
                donhangUpdate.TenSanPham = model.TenSanPham;
                donhangUpdate.SoLuong = model.SoLuong;
                donhangUpdate.GiaBan = model.GiaBan;
                donhangUpdate.UpdateTime = DateOnly.FromDateTime(DateTime.Now);
                _context.ChiTietDonHangs!.Update(donhangUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
