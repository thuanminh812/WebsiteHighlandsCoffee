using HighlandsCoffee.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HighlandsCoffeeBackend.Models
{
    public class HighlandsCoffeeDbContext:IdentityDbContext<ApplicationUser>
    {
        public HighlandsCoffeeDbContext()
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public DateOnlyConverter() : base(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }
        public HighlandsCoffeeDbContext(DbContextOptions<HighlandsCoffeeDbContext> options)
           : base(options)
        {
        }

        public  DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; } 
        public  DbSet<DanhMucMenu> DanhMucMenus { get; set; } 
        public  DbSet<DanhMucTinTuc> DanhMucTinTucs { get; set; } 
        public  DbSet<DonHang> DonHangs { get; set; } 
        public  DbSet<Menu> Menus { get; set; }
        public  DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<KhuVuc> KhuVucs { get; set; }
        public DbSet<PhanHoi> PhanHois { get; set; }
    }
}
