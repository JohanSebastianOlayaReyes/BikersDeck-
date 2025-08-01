using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class MazoData : BaseModelData<Mazo>, IMazoData
    {
        public MazoData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(Mazo mazo)
        {
            var existingMazo = await _dbSet.FindAsync(mazo.Id);
            foreach (var prop in typeof(Mazo).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(mazo);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingMazo, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var mazo = await _context.Set<Mazo>().FindAsync(id);
            if (mazo == null)
                return false;

            mazo.Active = active;
            _context.Entry(mazo).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
