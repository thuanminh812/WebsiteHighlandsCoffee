using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffeeBackend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighlandsCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRes _res;
        public MenuController(IMenuRes repo)
        {
            _res = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetMenuAsync());
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
            var phanhoi = await _res.GetMenuAsyncById(id);
            return phanhoi == null ? NotFound() : Ok(phanhoi);
        }
        [HttpGet]
        [Route("menuid/{id}")]
        public async Task<IActionResult> GetByMenuId(Guid id)
        {
            var phanhoi = await _res.GetMenuAsyncByMenuId(id);
            return phanhoi == null ? NotFound() : Ok(phanhoi);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(MenuModel model)
        {
                await _res.AddMenu(model);
            return Ok("Success");
        }
        [HttpPost]
        [Route("uploadimage")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file)
        {
            if (file == null || file.Length == 0 )
            {
                return BadRequest("No file upload");
                
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", file.FileName);
            using (var stream  = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("https://localhost:7096/Images/"+file.FileName);
        }    
        

        [HttpPut]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Update(Guid id, MenuModel model)
        {
            await _res.UpdateMenu(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        /*[Authorize(Roles = UserRoles.Admin)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }    
            await _res.DeleteMenu(id);
            return Ok(id);
        }
    }
}
