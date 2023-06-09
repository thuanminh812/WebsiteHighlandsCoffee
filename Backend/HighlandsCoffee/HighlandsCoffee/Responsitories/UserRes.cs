using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HighlandsCoffee.Responsitories
{
    public class UserRes : IUserRes
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
       private readonly IConfiguration configuration;
        public UserRes(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        public async Task<(int,string)> LoginAsync(Login model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return (0, "Invalid email");
            if (!await userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid password");
            var userRoles = await userManager.GetRolesAsync(user);
            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Name,user.DiaChi),
                new Claim(ClaimTypes.GivenName,user.SoDienThoai),
                new Claim(ClaimTypes.Anonymous,user.Id),
            };
            foreach (var userRole in userRoles)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaim);
            return (1, token);
        }
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var tokenDes = new SecurityTokenDescriptor
            {
                Issuer = configuration["JWT:ValidIssuer"],
                Audience = configuration["JWT:ValidAudience"],
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDes);
            return tokenHandler.WriteToken(token);
        }
        public async Task<(int,string)> RegisterAsync(Register model,string role)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);
            if (userExist != null)
                return (0, "Đã có tài khoản này");
            ApplicationUser user = new ApplicationUser
            {
                DiaChi = model.DiaChi,
                SoDienThoai = model.SoDienThoai,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };
            var createUserResult = await userManager.CreateAsync(user, model.Password);
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
            if (await roleManager.RoleExistsAsync(role))
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            return (1, "Tạo tài khoản thành công");
        }

        public async Task<(int, string)> RegisterUserAsync(Register model, string role)
        {
            var userExist = await userManager.FindByEmailAsync(model.Email);
            if (userExist != null)
                return (0, "Đã có tài khoản này");
            ApplicationUser user = new ApplicationUser
            {
                DiaChi = model.DiaChi,
                SoDienThoai = model.SoDienThoai,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };
            var createUserResult = await userManager.CreateAsync(user, model.Password);
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
            if (await roleManager.RoleExistsAsync(role))
                await userManager.AddToRoleAsync(user, UserRoles.User);
            return (1, "Tạo tài khoản thành công");
        }
    }
}
