using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighlandsCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanHoiController : ControllerBase
    {
        private readonly IPhanHoiRes _res;
        public PhanHoiController(IPhanHoiRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetPhanHoiAsync());
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
            var danhmucmenu = await _res.GetPhanHoiAsyncById(id);
            return danhmucmenu == null ? NotFound() : Ok(danhmucmenu);
        }
        [HttpPost]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Add(PhanHoiModel model)
        {
            try
            {
                var newdanhmuc = await _res.AddPhanHoi(model);
                return Ok(newdanhmuc);
            }
            catch
            {

                return BadRequest();
            }

        }
        [HttpPut]
        [Route("{id}")]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Update(Guid id, PhanHoiModel model)
        {
            await _res.UpdatePhanHoi(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeletePhanHoi(id);
            return Ok(id);
        }
    }
}
