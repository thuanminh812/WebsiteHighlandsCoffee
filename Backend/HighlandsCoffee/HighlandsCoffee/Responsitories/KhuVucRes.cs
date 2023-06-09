using AutoMapper;
using HighlandsCoffee.DtoModels;
using HighlandsCoffee.IResponsitories;
using HighlandsCoffee.Models;
using HighlandsCoffeeBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HighlandsCoffee.Responsitories
{
    public class KhuVucRes : IKhuVucRes
    {
        private readonly HighlandsCoffeeDbContext _context;
        private readonly IMapper _mapper;
        public KhuVucRes(HighlandsCoffeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddKhuVuc(KhuVucModel model)
        {
            var KhuVucNew = _mapper.Map<KhuVuc>(model);
            KhuVucNew = new KhuVuc
            {
                TenKhuVuc = model.TenKhuVuc
            };

            _context.KhuVucs!.Add(KhuVucNew);
            await _context.SaveChangesAsync();
            return KhuVucNew.IdKhuVuc;
        }

        public async Task DeleteKhuVuc(Guid id)
        {
            var xoaCart = _context.KhuVucs!.SingleOrDefault(x => x.IdKhuVuc == id);
            if (xoaCart != null)
            {
                _context.KhuVucs.Remove(xoaCart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<KhuVucModel>> GetKhuVucAsync()
        {
            var cart = await _context.KhuVucs.ToListAsync();
            return _mapper.Map<List<KhuVucModel>>(cart);
        }

        public async Task<KhuVucModel> GetKhuVucAsyncById(Guid id)
        {
            var cart = await _context.KhuVucs!.FindAsync(id);
            return _mapper.Map<KhuVucModel>(cart);
        }

        public async Task UpdateKhuVuc(Guid id, KhuVucModel model)
        {
            var cartUpdate = _mapper.Map<KhuVuc>(model);
            if (id! == model.IdKhuVuc)
            {
                cartUpdate = _context.KhuVucs.FirstOrDefault(x => x.IdKhuVuc == id);
                cartUpdate.TenKhuVuc = model.TenKhuVuc;
                _context.KhuVucs!.Update(cartUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
