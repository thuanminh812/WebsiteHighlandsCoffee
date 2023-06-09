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
    public class CuaHangController : ControllerBase
    {
        private readonly ICuaHangRes _res;
        public CuaHangController(ICuaHangRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetCuaHangAsync());
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
            var danhmucmenu = await _res.GetCuaHangAsyncById(id);
            return danhmucmenu == null ? NotFound() : Ok(danhmucmenu);
        }
        [HttpPost]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(CuaHangModel model)
        {
            try
            {
                var newdanhmuc = await _res.AddCuaHang(model);
                return Ok(newdanhmuc);
            }
            catch
            {

                return BadRequest();
            }

        }
        [HttpGet]
        [Route("cuahangid/{id}")]
        public async Task<IActionResult> GetByKhuVucId(Guid id)
        {
            var phanhoi = await _res.GetCuaHangAsyncByIdKhuVuc(id);
            return phanhoi == null ? NotFound() : Ok(phanhoi);
        }
        [HttpPost]
        [Route("uploadimage")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file upload");

            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("https://localhost:7096/Images/" + file.FileName);
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Update(Guid id, CuaHangModel model)
        {
            await _res.UpdateCuaHang(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteCuaHang(id);
            return Ok(id);
        }
    }
}
