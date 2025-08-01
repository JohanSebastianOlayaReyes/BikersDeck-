using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class RoundData : BaseModelData<Round>, IRoundData
    {
        public RoundData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(Round round)
        {
            var existingRound = await _dbSet.FindAsync(round.Id);
            foreach (var prop in typeof(Round).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(round);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingRound, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var round = await _context.Set<Round>().FindAsync(id);
            if (round == null)
                return false;

            round.Active = active;
            _context.Entry(round).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
