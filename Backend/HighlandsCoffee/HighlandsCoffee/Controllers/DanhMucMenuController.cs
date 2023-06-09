using HighlandsCoffee.DtoModels;
using HighlandsCoffeeBackend.DtoModels;
using HighlandsCoffeeBackend.IResponsitories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighlandsCoffeeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucMenuController : ControllerBase
    {
        private readonly IDanhMucMenuRes _res;
        public DanhMucMenuController(IDanhMucMenuRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetDanhMucMenuAsync());
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var danhmucmenu = await _res.GetDanhMucAsyncById(id);
            return danhmucmenu == null ? NotFound() : Ok(danhmucmenu);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Add(DanhMucMenuModel model)
        {
            try
            {
                var newdanhmuc = await _res.AddDanhMucMenu(model);
                return Ok(newdanhmuc);
            }
            catch
            {

                return BadRequest();
            }

        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Update(Guid id, DanhMucMenuModel model)
        {
            await _res.UpdateDanhMucMenu(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteDanhMucMenu(id);
            return Ok(id);
        }
    }
}
