using Entity.Dtos.Base;

namespace Entity.Dtos.PizzaDto
{
    public class RoomPlayersUpdateDto : GenericDto
    {
        public int NamePlayer { get; set; }
        public string Avatar { get; set; }
        public int PlayersId { get; set; }
    }
}
