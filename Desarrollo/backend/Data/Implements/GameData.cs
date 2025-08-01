using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class GameData : BaseModelData<Game>, IGameData
    {
        public GameData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(Game game)
        {
            var existingGame = await _dbSet.FindAsync(game.Id);
            foreach (var prop in typeof(Game).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(game);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingGame, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var game = await _context.Set<Game>().FindAsync(id);
            if (game == null)
                return false;

            game.Active = active;
            _context.Entry(game).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
