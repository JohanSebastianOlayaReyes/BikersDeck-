using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class MazoData : BaseModelData<Mazo>, IMazoData
    {
        public MazoData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var mazo = await _context.Set<Mazo>().FindAsync(id);
            if (mazo == null)
                return false;

            mazo.Status = active;
            mazo.DeleteAt = DateTime.UtcNow;

            _context.Entry(mazo).Property(m => m.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Mazo mazo)
        {
            var existingMazo = await _context.Mazos.FindAsync(mazo.Id);
            if (existingMazo == null)
                return false;

            existingMazo.QuantityCards = mazo.QuantityCards;

            _context.Entry(existingMazo).Property(m => m.QuantityCards).IsModified = true;


            await _context.SaveChangesAsync();
            return true;
        }
    }
}
