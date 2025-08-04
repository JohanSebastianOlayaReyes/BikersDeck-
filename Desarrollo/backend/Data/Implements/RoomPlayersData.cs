using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class RoomPlayerData : BaseModelData<RoomPlayers>, IRoomPlayersData
    {
        public RoomPlayerData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var roomPlayer = await _context.Set<RoomPlayers>().FindAsync(id);
            if (roomPlayer == null)
                return false;

            roomPlayer.Status = active;
            roomPlayer.DeleteAt = DateTime.UtcNow;

            _context.Entry(roomPlayer).Property(rp => rp.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(RoomPlayers roomPlayer)
        {
            var existingRoomPlayer = await _context.RoomPlayers.FindAsync(roomPlayer.Id);
            if (existingRoomPlayer == null)
                return false;

            // Solo se actualizan campos permitidos
            existingRoomPlayer.NamePlayer = roomPlayer.NamePlayer;
            existingRoomPlayer.Avatar = roomPlayer.Avatar;
     

            _context.Entry(existingRoomPlayer).Property(rp => rp.NamePlayer).IsModified = true;
            _context.Entry(existingRoomPlayer).Property(rp => rp.Avatar).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
