using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace HighlandsCoffee.Responsitories
{
    public class MenuRes : IMenuRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public MenuRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddMenu( MenuModel model)
        {
            var menuNew = _mapper.Map<Menu>(model);
            menuNew = new Menu
            {
                IdSanPham = model.IdSanPham,
                MenuId = model.MenuId,
                HinhAnh = model.HinhAnh,
                TenSanPham = model.TenSanPham,
                GiaBan = model.GiaBan,
                MotaSanPham = model.MotaSanPham,
                LinkUrl = model.LinkUrl,           
                NgayTao = DateOnly.FromDateTime(DateTime.Now),
                UpdateTime = DateOnly.FromDateTime(DateTime.Now)
            };
            _context.Menus!.Add(menuNew);
            await _context.SaveChangesAsync();
            return menuNew.IdSanPham;
        }

        public async Task DeleteMenu(Guid id)
        {
            var xoaMenu = _context.Menus.FirstOrDefault(x => x.IdSanPham == id);
            if (xoaMenu != null)
            {
                _context.Menus.Remove(xoaMenu);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MenuModel>> GetMenuAsync()
        {
            var menus = await _context.Menus.ToListAsync();
            return _mapper.Map<List<MenuModel>>(menus);
        }

        public async Task<MenuModel> GetMenuAsyncById(Guid id)
        {
            var menu = await _context.Menus!.FindAsync(id);
            return _mapper.Map<MenuModel>(menu);
        }

        public async Task<List<MenuModel>> GetMenuAsyncByMenuId(Guid id)
        {
            var menu = _context.Menus.Where(x => x.MenuId == id);
            return _mapper.Map<List<MenuModel>>(menu);
        }

        public async Task UpdateMenu(Guid id, MenuModel model)
        {
            var menuUpdate = _mapper.Map<Menu>(model);
            if (id! == model.IdSanPham)
            {
                menuUpdate = _context.Menus.FirstOrDefault(x => x.IdSanPham == id);
                menuUpdate.MenuId = model.MenuId;
                menuUpdate.HinhAnh = model.HinhAnh;
                menuUpdate.TenSanPham = model.TenSanPham;
                menuUpdate.GiaBan = model.GiaBan;
                menuUpdate.MotaSanPham = model.MotaSanPham;
                menuUpdate.LinkUrl = model.LinkUrl;
                menuUpdate.UpdateTime = DateOnly.FromDateTime(DateTime.Now);
                _context.Menus!.Update(menuUpdate);
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
