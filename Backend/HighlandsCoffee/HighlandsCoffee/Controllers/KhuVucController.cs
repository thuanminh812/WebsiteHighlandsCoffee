using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighlandsCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuVucController : ControllerBase
    {
        private readonly IKhuVucRes _res;
        public KhuVucController(IKhuVucRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetKhuVucAsync());
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
            var danhmucmenu = await _res.GetKhuVucAsyncById(id);
            return danhmucmenu == null ? NotFound() : Ok(danhmucmenu);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Add(KhuVucModel model)
        {
            try
            {
                var newdanhmuc = await _res.AddKhuVuc(model);
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
        public async Task<IActionResult> Update(Guid id, KhuVucModel model)
        {
            await _res.UpdateKhuVuc(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteKhuVuc(id);
            return Ok(id);
        }
    }
}
