using Data.Implements.BaseData;
using Data.Interfaces;
using Entity.Model;

namespace Data.Implements
{
    public class RoomPlayerData : BaseModelData<RoomPlayers>, IRoomPlayersData
    {
        public RoomPlayerData(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> UpdatePartial(RoomPlayers roomplayers)
        {
            var existingRoomPlayers = await _dbSet.FindAsync(roomplayers.Id);
            foreach (var prop in typeof(RoomPlayers).GetProperties().Where(p => p.CanWrite && p.Name != "Id"))
            {
                var val = prop.GetValue(roomplayers);
                if (val != null && (!(val is string s) || !string.IsNullOrWhiteSpace(s)))
                    prop.SetValue(existingRoomPlayers, val);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var roomplayers = await _context.Set<RoomPlayers>().FindAsync(id);
            if (roomplayers == null)
                return false;

            roomplayers.Active = active;
            _context.Entry(roomplayers).Property(c => c.Active).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
