using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighlandsCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly IChiTietDonHangRes _res;
        private List<ChiTietDonHangModel> ch = new List<ChiTietDonHangModel>();
        public ChiTietDonHangController(IChiTietDonHangRes repo)
        {
            _res = repo;
        }
        [HttpGet]
/*        [Authorize]*/
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _res.GetChiTietDonHangAsync());
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpGet]
        [Route("{id}")]
        /*        [Authorize]*/
        public async Task<IActionResult> GetById(Guid id)
        {
            var donhang = await _res.GetChiTietDonHangAsyncById(id);
            return donhang == null ? NotFound() : Ok(donhang);
        }
        [HttpGet]
        [Route("donhang/{id}")]
        public async Task<IActionResult> GetByDonHangId(Guid id)
        {
            var phanhoi = await _res.GetChiTietDonHangAsyncByDonHangId(id);
            return phanhoi == null ? NotFound() : Ok(phanhoi);
        }
        [HttpPost]
/*        [Authorize(Roles = UserRoles.User)]*/
        public async Task<IActionResult> Add(ChiTietDonHangModel model)
        {

            await _res.AddChiTietDonHang(model);
            return Ok("Success");
        }

        [HttpPut]
        [Route("{id}")]
        /*        [Authorize(Roles = UserRoles.User)]*/
        public async Task<IActionResult> Update(Guid id, ChiTietDonHangModel model)
        {
            await _res.UpdateChiTietDonHang(id, model);
            return Ok("Success");
        }
        [HttpDelete]
        [Route("{id}")]
        /*        [Authorize(Roles = UserRoles.User)]*/
        public async Task<IActionResult> Delete(Guid id)
        {
            await _res.DeleteChiTietDonHang(id);
            return Ok(id);
        }
    }
}
