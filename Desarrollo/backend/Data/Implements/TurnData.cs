using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class TurnData : BaseModelData<Turn>, ITurnData
    {
        public TurnData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(Turn turn)
        {
            var existingTurn = await _dbSet.FindAsync(turn.Id);
            foreach (var prop in typeof(Turn).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(turn);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingTurn, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var turn = await _context.Set<Turn>().FindAsync(id);
            if (turn == null)
                return false;

            turn.Active = active;
            _context.Entry(turn).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
