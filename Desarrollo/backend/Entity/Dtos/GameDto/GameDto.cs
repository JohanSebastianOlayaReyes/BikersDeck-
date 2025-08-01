using Entity.Dtos.Base;

namespace Entity.Dtos.ClienteDto
{
    public class GameDto : GenericDto
    {
        public DateTime Time { get; set; }
        public int RoomPlayersId { get; set; }
        public int MazoId { get; set; }
    }
}
