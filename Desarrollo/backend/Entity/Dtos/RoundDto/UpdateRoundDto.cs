using Entity.Dtos.Base;

namespace Entity.Dtos.RoundDto
{
    public class UpdateRoundDto : GenericDto
    {
        public int Points { get; set; }
        public int GameId { get; set; }
    }
}