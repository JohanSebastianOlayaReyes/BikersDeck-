using Entity.Model.Base;
// Partida
namespace Entity.Model
{
    public class Game : GenericBase
    {
        public DateTime Time { get; set; }
        public RoomPlayers RoomPlayers { get; set; }
        public int RoomPlayersId { get; set; }
        public Mazo Mazo { get; set; }
        public int MazoId { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}
