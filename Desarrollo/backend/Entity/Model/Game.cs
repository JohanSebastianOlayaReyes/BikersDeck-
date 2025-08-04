using Entity.Model.Base;
// Partida
namespace Entity.Model
{
    public class Game : GenericBase
    {
        public DateTime Time { get; set; }
        public RoomPlayers RoomPlayers { get; set; }
        public int RoomPlayersId { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public ICollection<Mazo> Mazos { get; set; }
    }
}
