using Entity.Model.Base;

namespace Entity.Model
{
    public class Players : GenericBase
    {
        public string QuantityPlayers { get; set; }
        public ICollection<RoomPlayers> RoomPlayers { get; set; }
    }
}
