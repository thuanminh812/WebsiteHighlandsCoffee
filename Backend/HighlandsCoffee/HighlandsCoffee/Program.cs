using HighlandsCoffee.IResponsitories;
using HighlandsCoffee.Models;
using HighlandsCoffee.Responsitories;
using HighlandsCoffeeBackend.IResponsitories;
using HighlandsCoffeeBackend.Models;
using HighlandsCoffeeBackend.Responsitories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HighlandsCoffeeDbContext>(options
    => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnect"));
    });
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HighlandsCoffeeDbContext>().AddDefaultTokenProviders();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IDanhMucMenuRes, DanhMucMenuRes>();
builder.Services.AddScoped<IDanhMucTinTucRes, DanhMucTinTucRes>();
builder.Services.AddScoped<IMenuRes, MenuRes>();
builder.Services.AddScoped<ITinTucRes, TinTucRes>();
builder.Services.AddScoped<IDonHangRes, DonHangRes>();
builder.Services.AddScoped<IChiTietDonHangRes, ChiTietDonHangRes>();
builder.Services.AddScoped<IUserRes, UserRes>();
builder.Services.AddScoped<ICuaHangRes, CuaHangRes>();
builder.Services.AddScoped<IKhuVucRes, KhuVucRes>();
builder.Services.AddScoped<IPhanHoiRes, PhanHoiRes>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer  = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 100000000;
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 100000000;
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

