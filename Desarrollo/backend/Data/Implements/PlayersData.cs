using Back_end.Context;
using Data.Interface;
using Entity.Model;

namespace Data.Implements.BaseData
{
    public class PlayerData : BaseModelData<Players>, IPlayerData
    {
        public PlayerData(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ActiveAsync(int id, bool active)
        {
            var player = await _context.Set<Players>().FindAsync(id);
            if (player == null)
                return false;

            // Actualizar el estado del jugador
            player.Status = active;
            player.DeleteAt = DateTime.UtcNow;

            _context.Entry(player).Property(p => p.Status).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePartial(Players player)
        {
            var existingPlayer = await _context.Players.FindAsync(player.Id);
            if (existingPlayer == null)
                return false;

            // Solo se actualizan campos permitidos
            existingPlayer.QuantityPlayers = player.QuantityPlayers;

            // Marcar explícitamente los campos modificados
            _context.Entry(existingPlayer).Property(p => p.QuantityPlayers).IsModified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        //metodo para guardar la cantidad de jugadores
        private readonly Dictionary<int, int> _players = new();
        private int _playerIdCounter = 1;

        public int Quantity(int QuantityPlayer)
        {
            int id = _playerIdCounter++;
            _players[id] = QuantityPlayer;
            return id;
        }
        public int GetQuantity(int PlayersId)
        {
            return _players.TryGetValue(PlayersId, out int Quantity) ? Quantity : 0;
        }
    }
}
