using AutoMapper;
using HighlandsCoffeeBackend.DtoModels;
using HighlandsCoffeeBackend.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffeeBackend.Responsitories
{
    public class DanhMucMenuRes : IDanhMucMenuRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public DanhMucMenuRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddDanhMucMenu(DanhMucMenuModel model)
        {
            var danhmucNew = _mapper.Map<DanhMucMenu>(model);
            danhmucNew = new DanhMucMenu
            {
                MenuId = model.MenuId,
                TenDanhMuc = model.TenDanhMuc,
                MotaDanhMuc = model.MotaDanhMuc
            };
            _context.DanhMucMenus!.Add(danhmucNew);
            await _context.SaveChangesAsync();
            return danhmucNew.MenuId;
        }

        public async Task DeleteDanhMucMenu(Guid ten)
        {
            var xoaDanhMuc = _context.DanhMucMenus.FirstOrDefault(x => x.MenuId == ten);
            if (xoaDanhMuc != null)
            {
                _context.DanhMucMenus.Remove(xoaDanhMuc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DanhMucMenuModel> GetDanhMucAsyncById(Guid ten)
        {
            var danhmucMenu = await _context.DanhMucMenus.FindAsync(ten);
            return _mapper.Map<DanhMucMenuModel>(danhmucMenu);
        }

        public async Task<List<DanhMucMenuModel>> GetDanhMucMenuAsync()
        {
            var danhmucMenus = await _context.DanhMucMenus.ToListAsync();
            return _mapper.Map<List<DanhMucMenuModel>>(danhmucMenus);
        }

        public async Task UpdateDanhMucMenu(Guid ten, DanhMucMenuModel model)
        {
            var danhmucUpdate = _mapper.Map<DanhMucMenu>(model);
            if (ten! == model.MenuId)
            {
                danhmucUpdate = _context.DanhMucMenus!.FirstOrDefault(x => x.MenuId == ten);
                danhmucUpdate.TenDanhMuc = model.TenDanhMuc;
                danhmucUpdate.MotaDanhMuc = model.MotaDanhMuc;
                _context.DanhMucMenus!.Update(danhmucUpdate);
                await _context.SaveChangesAsync();

            }
        }
    }
}
