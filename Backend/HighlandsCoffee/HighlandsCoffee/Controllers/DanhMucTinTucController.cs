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
    public class DanhMucTinTucController : ControllerBase
    {
        private readonly IDanhMucTinTucRes _res;
        public DanhMucTinTucController(IDanhMucTinTucRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetDanhMucAsync());
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
            var danhmuc = await _res.GetDanhMucAsyncById(id);
            return danhmuc == null ? NotFound() : Ok(danhmuc);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Add(DanhMucTinTucModel model)
        {
            try
            {
                var newdanhmuc = await _res.AddDanhMuc(model);
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
        public async Task<IActionResult> Update(Guid id, DanhMucTinTucModel model)
        {
            await _res.UpdateDanhMuc(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteDanhMuc(id);
            return Ok(id);
        }
    }
}
