using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;
// Mazo
namespace Entity.Model
{
    public class Mazo : GenericBase
    {
        public int QuantityCards { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public ICollection<Game> Game { get; set; }

    }
}
