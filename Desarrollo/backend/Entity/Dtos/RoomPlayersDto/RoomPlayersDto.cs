using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.PedidoDto
{
    public class RoomPlayersDto : BaseDto
    {
        public string NamePlayer { get; set; }
        public string Avatar { get; set; }
        public int PlayersId { get; set; }

    }
}
