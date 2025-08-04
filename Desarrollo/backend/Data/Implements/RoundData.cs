using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class RoundData : BaseModelData<Round>, IRoundData
    {
        public RoundData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var round = await _context.Set<Round>().FindAsync(id);
            if (round == null)
                return false;

            round.Status = active;
            round.DeleteAt = DateTime.UtcNow;

            _context.Entry(round).Property(r => r.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Round round)
        {
            var existingRound = await _context.Rounds.FindAsync(round.Id);
            if (existingRound == null)
                return false;

            existingRound.Points = round.Points;


            _context.Entry(existingRound).Property(r => r.Points).IsModified = true;


            await _context.SaveChangesAsync();
            return true;
        }
    }
}
