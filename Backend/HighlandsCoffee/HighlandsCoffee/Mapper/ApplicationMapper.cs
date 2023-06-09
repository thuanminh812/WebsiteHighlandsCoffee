using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.Models;
using HighlandsCoffeeBackend.DtoModels;
using HighlandsCoffeeBackend.Models;

namespace HighlandsCoffeeBackend.Mapper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DanhMucMenu, DanhMucMenuModel>().ReverseMap();
            CreateMap<DanhMucTinTuc, DanhMucTinTucModel>().ReverseMap();
            CreateMap<Menu, MenuModel>().ReverseMap();
            CreateMap<TinTuc, TinTucModel>().ReverseMap();
            CreateMap<DonHang, DonHangModel>().ReverseMap();
            CreateMap<ChiTietDonHang, ChiTietDonHangModel>().ReverseMap();
            CreateMap<CuaHang, CuaHangModel>().ReverseMap();
            CreateMap<KhuVuc, KhuVucModel>().ReverseMap();
            CreateMap<PhanHoi, PhanHoiModel>().ReverseMap();
        }
    }
}
