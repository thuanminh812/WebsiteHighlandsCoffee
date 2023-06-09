using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffee.Models;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffee.Responsitories
{
    public class PhanHoiRes : IPhanHoiRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public PhanHoiRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddPhanHoi(PhanHoiModel model)
        {
            var cartNew = _mapper.Map<PhanHoi>(model);
            cartNew = new PhanHoi
            {
                Email = model.Email,
                HoTen = model.HoTen,
                SoDienThoai = model.SoDienThoai,
                NoiDung = model.NoiDung,
            };

            _context.PhanHois!.Add(cartNew);
            await _context.SaveChangesAsync();
            return cartNew.Id;
        }

        public async Task DeletePhanHoi(Guid id)
        {
            var xoaCart = _context.PhanHois!.SingleOrDefault(x => x.Id == id);
            if (xoaCart != null)
            {
                _context.PhanHois.Remove(xoaCart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PhanHoiModel>> GetPhanHoiAsync()
        {
            var cart = await _context.PhanHois.ToListAsync();
            return _mapper.Map<List<PhanHoiModel>>(cart);
        }

        public async Task<PhanHoiModel> GetPhanHoiAsyncById(Guid id)
        {
            var cart = await _context.PhanHois!.FindAsync(id);
            return _mapper.Map<PhanHoiModel>(cart);
        }

        public async Task UpdatePhanHoi(Guid id, PhanHoiModel model)
        {
            var cartUpdate = _mapper.Map<PhanHoi>(model);
            if (id! == model.Id)
            {
                cartUpdate = _context.PhanHois.FirstOrDefault(x => x.Id == id);
                cartUpdate.Email = model.Email;
                cartUpdate.HoTen = model.HoTen;
                cartUpdate.SoDienThoai = model.SoDienThoai;
                cartUpdate.NoiDung = model.NoiDung;
                _context.PhanHois!.Update(cartUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
