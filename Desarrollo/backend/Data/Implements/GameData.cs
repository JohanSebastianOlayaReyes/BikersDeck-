using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class GameData : BaseModelData<Game>, IGameData
    {
        public GameData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var game = await _context.Set<Game>().FindAsync(id);
            if (game == null)
                return false;

            game.Status = active;
            game.DeleteAt = DateTime.UtcNow;

            _context.Entry(game).Property(g => g.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Game game)
        {
            var existingGame = await _context.Games.FindAsync(game.Id);
            if (existingGame == null)
                return false;

            // Actualizar campos permitidos
            existingGame.Time = game.Time;

            _context.Entry(existingGame).Property(g => g.Time).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
