using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighlandsCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangRes _res;
        public DonHangController(IDonHangRes repo)
        {
            _res = repo;
        }
        [HttpGet]
/*        [Authorize]*/
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetDonHangAsync());
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpGet("{id}")]
/*        [Authorize]*/
        public async Task<IActionResult> GetByPhanHoiId(Guid id)
        {
            var donhang = await _res.GetDonHangAsyncById(id);
            return donhang == null ? NotFound() : Ok(donhang);
        }
        [HttpPost]
/*        [Authorize(Roles = UserRoles.User)]*/
        public async Task<IActionResult> Add( DonHangModel model)
        {

            var idDonHang = await _res.AddDonHang(model);
            return Ok(idDonHang);
        }

        [HttpPut("{id}")]
/*        [Authorize(Roles = UserRoles.User)]*/
        public async Task<IActionResult> Update(Guid id, DonHangModel model)
        {
            await _res.UpdateDonHang(id, model);
            return Ok("Success");
        }
        [HttpDelete("{id}")]
/*        [Authorize]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteDonHang(id);
            return Ok(id);
        }
    }
}
