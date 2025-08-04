using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class TurnData : BaseModelData<Turn>, ITurnData
    {
        public TurnData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var turn = await _context.Set<Turn>().FindAsync(id);
            if (turn == null)
                return false;

            turn.Status = active;
            turn.DeleteAt = DateTime.UtcNow;

            _context.Entry(turn).Property(t => t.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Turn turn)
        {
            var existingTurn = await _context.Turns.FindAsync(turn.Id);
            if (existingTurn == null)
                return false;

            existingTurn.Time = turn.Time;
            existingTurn.Attribute = turn.Attribute;

            _context.Entry(existingTurn).Property(t => t.RoundId).IsModified = true;
            _context.Entry(existingTurn).Property(t => t.Attribute).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
