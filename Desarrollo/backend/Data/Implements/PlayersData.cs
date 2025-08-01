using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class PlayerData : BaseModelData<Players>, IPlayersData
    {
        public PlayerData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(Players players)
        {
            var existingPlayers = await _dbSet.FindAsync(players.Id);
            foreach (var prop in typeof(Players).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(players);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingPlayers, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var players = await _context.Set<Players>().FindAsync(id);
            if (players == null)
                return false;

            players.Active = active;
            _context.Entry(players).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
