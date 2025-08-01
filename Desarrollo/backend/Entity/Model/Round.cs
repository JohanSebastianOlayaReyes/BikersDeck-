using Entity.Model.Base;
// Ronda
namespace Entity.Model
{
    public class Round : GenericBase

    {
        public int Points { get; set; }
        public  Game Game { get; set; }
        public int GameId { get; set; }
        public ICollection<Turn> Turns { get; set; }
    }
}
