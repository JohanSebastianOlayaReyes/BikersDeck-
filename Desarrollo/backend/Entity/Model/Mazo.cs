using Entity.Model.Base;
// Mazo
namespace Entity.Model
{
    public class Mazo : GenericBase
    {
        public int QuantityCards { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Card card { get; set; }
        public int CardId { get; set; } 

    }
}
