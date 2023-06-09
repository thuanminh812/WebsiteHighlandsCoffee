using AutoMapper;
using HighlandsCoffeeBackend.DtoModels;
using HighlandsCoffeeBackend.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffeeBackend.Responsitories
{
    public class DanhMucTinTucRes : IDanhMucTinTucRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public DanhMucTinTucRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddDanhMuc(DanhMucTinTucModel model)
        {
            var danhmucNew = _mapper.Map<DanhMucTinTuc>(model);
            danhmucNew = new DanhMucTinTuc
                {
                    TinTucId = model.TinTucId,
                    TenDanhMuc = model.TenDanhMuc,
                    MotaDanhMuc = model.MotaDanhMuc
                }; 
            
            _context.DanhMucTinTucs!.Add(danhmucNew);
            await _context.SaveChangesAsync();
            return danhmucNew.TinTucId;
        }

        public async Task DeleteDanhMuc(Guid ten)
        {
            var xoaDanhMuc = _context.DanhMucTinTucs.FirstOrDefault(x => x.TinTucId == ten);
            if (xoaDanhMuc != null)
            {
                _context.DanhMucTinTucs.Remove(xoaDanhMuc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DanhMucTinTucModel>> GetDanhMucAsync()
        {
            var danhmucs = await _context.DanhMucTinTucs.ToListAsync();
            return _mapper.Map<List<DanhMucTinTucModel>>(danhmucs);
        }

        public async Task<DanhMucTinTucModel> GetDanhMucAsyncById(Guid ten)
        {
            var danhmuc = await _context.DanhMucTinTucs.FindAsync(ten);
            return _mapper.Map<DanhMucTinTucModel>(danhmuc);
        }

        public async Task UpdateDanhMuc(Guid ten, DanhMucTinTucModel model)
        {
            var danhmucUpdate = _mapper.Map<DanhMucTinTuc>(model);
            if (ten! == model.TinTucId)
            {
                danhmucUpdate = _context.DanhMucTinTucs!.FirstOrDefault(x => x.TinTucId == ten);
                danhmucUpdate.TenDanhMuc = model.TenDanhMuc;
                danhmucUpdate.MotaDanhMuc = model.MotaDanhMuc;
                _context.DanhMucTinTucs!.Update(danhmucUpdate);
                await _context.SaveChangesAsync();

            }
        }
    }
}
