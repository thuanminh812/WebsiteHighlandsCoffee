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
    public class TinTucController : ControllerBase
    {
        private readonly ITinTucRes _res;
        public TinTucController(ITinTucRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetTinTucAsync());
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
            var tintuc = await _res.GetTinTucAsyncById(id);
            return tintuc == null ? NotFound() : Ok(tintuc);
        }
        [HttpGet]
        [Route("tintucid/{id}")]
        public async Task<IActionResult> GetByTinTucId(Guid id)
        {
            var phanhoi = await _res.GetTinTucAsyncByTinTucId(id);
            return phanhoi == null ? NotFound() : Ok(phanhoi);
        }
        [HttpPost]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(TinTucModel model)
        {

            await _res.AddTinTuc(model);
            return Ok("Success");
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
                file.CopyToAsync(stream);
            }
            return Ok("https://localhost:7096/Images/" + file.FileName);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Update(Guid id, TinTucModel model)
        {
            await _res.UpdateTinTuc(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteTinTuc(id);
            return Ok(id);
        }
    }
}

