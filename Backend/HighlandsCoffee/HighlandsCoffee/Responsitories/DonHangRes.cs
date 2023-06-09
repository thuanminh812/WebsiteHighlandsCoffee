using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffee.Responsitories
{
    public class DonHangRes : IDonHangRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public DonHangRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddDonHang(DonHangModel model)
        {
            var donhangNew = _mapper.Map<DonHang>(model);
            donhangNew = new DonHang
                {
                    IdDonHang = model.IdDonHang,
                    UserName = model.UserName,
                    DiaChi = model.DiaChi,
                    SoDienThoai = model.SoDienThoai,
                    TongTien = model.TongTien,
                    TrangThai = model.TrangThai,
                    NgayMua = DateOnly.FromDateTime(DateTime.Now),
                    UpdateTime = DateOnly.FromDateTime(DateTime.Now)
            };
            
            _context.DonHangs!.Add(donhangNew);
            await _context.SaveChangesAsync();
            return donhangNew.IdDonHang;
        }

        public async Task DeleteDonHang(Guid id)
        {
            var xoaDonHang = _context.DonHangs.SingleOrDefault(x => x.IdDonHang == id);
            if (xoaDonHang != null)
            {
                _context.DonHangs.Remove(xoaDonHang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DonHangModel>> GetDonHangAsync()
        {
            var menus = await _context.DonHangs.ToListAsync();
            return _mapper.Map<List<DonHangModel>>(menus);
        }

        public async Task<DonHangModel> GetDonHangAsyncById(Guid id)
        {
            var menu = await _context.DonHangs!.FindAsync(id);
            return _mapper.Map<DonHangModel>(menu);
        }

        public async Task UpdateDonHang(Guid id, DonHangModel model)
        {
            var donhangUpdate = _mapper.Map<DonHang>(model);
            if (id! == model.IdDonHang)
            {
                donhangUpdate = _context.DonHangs.FirstOrDefault(x => x.IdDonHang == id);
                donhangUpdate.TrangThai = model.TrangThai;
                donhangUpdate.UpdateTime = DateOnly.FromDateTime(DateTime.Now);
                _context.DonHangs!.Update(donhangUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
