using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffee.Responsitories
{
    public class TinTucRes : ITinTucRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public TinTucRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddTinTuc(TinTucModel model)
        {
            var tintucNew = _mapper.Map<TinTuc>(model);
            tintucNew = new TinTuc
            {
                Id = model.Id,
                TinTucId = model.TinTucId,
                HinhAnh = model.HinhAnh,
                TieuDe = model.TieuDe,
                MotaTinTuc = model.MotaTinTuc,
                LinkUrl = model.LinkUrl,
                NgayTao = DateOnly.FromDateTime(DateTime.Now),
                UpdateTime = DateOnly.FromDateTime(DateTime.Now)
            };
            
            _context.TinTucs!.Add(tintucNew);
            await _context.SaveChangesAsync();
            return tintucNew.Id;
        }

        public async Task DeleteTinTuc(Guid id)
        {
            var xoaTinTuc = _context.TinTucs.FirstOrDefault(x => x.Id == id);
            if (xoaTinTuc != null)
            {
                _context.TinTucs.Remove(xoaTinTuc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TinTucModel>> GetTinTucAsync()
        {
            var tintucs = await _context.TinTucs.ToListAsync();
            return _mapper.Map<List<TinTucModel>>(tintucs);
        }

        public async Task<TinTucModel> GetTinTucAsyncById(Guid id)
        {
            var tintuc = await _context.TinTucs!.FindAsync(id);
            return _mapper.Map<TinTucModel>(tintuc);
        }

        public async Task<List<TinTucModel>> GetTinTucAsyncByTinTucId(Guid id)
        {
            var tintuc = _context.TinTucs.Where(x => x.TinTucId == id);
            return _mapper.Map<List<TinTucModel>>(tintuc);
        }

        public async Task UpdateTinTuc(Guid id, TinTucModel model)
        {
            var tintucUpdate = _mapper.Map<TinTuc>(model);
            if (id! == model.Id)
            {
                tintucUpdate = _context.TinTucs.FirstOrDefault(x => x.Id == id);
                tintucUpdate.TinTucId = model.TinTucId;
                tintucUpdate.HinhAnh = model.HinhAnh;
                tintucUpdate.TieuDe = model.TieuDe;
                tintucUpdate.MotaTinTuc = model.MotaTinTuc;
                tintucUpdate.LinkUrl = model.LinkUrl;
                tintucUpdate.UpdateTime = DateOnly.FromDateTime(DateTime.Now);
                _context.TinTucs!.Update(tintucUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
