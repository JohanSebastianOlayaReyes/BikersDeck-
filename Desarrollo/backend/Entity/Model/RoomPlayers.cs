using Entity.Model.Base;
// SalaJugadores
namespace Entity.Model
{
    public class RoomPlayers : GenericBase
    {
        public string NamePlayer  { get; set; }
        public string Avatar { get; set; }
        public Players Players { get; set; }
        public int PlayersId { get; set; }
        public ICollection<Game> Game { get; set; }
    }
}   