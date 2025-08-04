using Entity.Dtos.Base;

namespace Entity.Dtos.TurnDto
{
    public class UpdateTurnDto : GenericDto
    {
        public DateTime Time { get; set; }
        public string Attribute { get; set; }
        public int RoundId { get; set; }
    }
}
