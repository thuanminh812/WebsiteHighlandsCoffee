using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffee.Models;
using HighlandsCoffeeBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HighlandsCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRes res;
        private readonly ILogger<AccountController> logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userMaganer;
        private readonly IHttpContextAccessor httpContext;
        public AccountController(IUserRes repo, ILogger<AccountController> logger, IHttpContextAccessor httpContext, UserManager<ApplicationUser> userManager)
        {
            res = repo;
            this.logger = logger;
            _userMaganer = userManager;
            this.httpContext = httpContext;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await res.RegisterAsync(model, UserRoles.Admin);
                if(status == 0)
                {
                    return BadRequest(message);
                }    
                return CreatedAtAction(nameof(Register), model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(Register model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await res.RegisterUserAsync(model, UserRoles.User);
                if (status == 0)
                {
                    return BadRequest(message);
                }
                return CreatedAtAction(nameof(Register), model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await res.LoginAsync(model);
                if (status == 0)
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUser()
        {
            var id = User.FindFirst(ClaimTypes.Anonymous)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var firstname = User.FindFirst(ClaimTypes.Name)?.Value;
            var lastname = User.FindFirst(ClaimTypes.GivenName)?.Value;
            var user = new UserDTO
            {
                Id = id,
                Email = email,
                Name = username,
                DiaChi =firstname,
                SoDienThoai = lastname
            };

            return Ok(user);
        }
        [HttpPut]
        [Route("updateUser/{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var userUpdate = await _userMaganer.FindByIdAsync(id);
            if (userUpdate == null)
            {
                return NotFound();
            }

            userUpdate.UserName = user.Name;
            userUpdate.DiaChi = user.DiaChi;
            userUpdate.SoDienThoai = user.SoDienThoai;

            var result = await _userMaganer.UpdateAsync(userUpdate);
            if (result.Succeeded)
            {
                return Ok("Success") ;
            }

            return BadRequest(result.Errors);
        }
    }
}
