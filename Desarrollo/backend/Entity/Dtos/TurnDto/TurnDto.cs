using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.PizzaDto
{
    public class TurnDto : GenericDto
    {
        public DateTime Time { get; set; }
        public string Attribute { get; set; }
        public int RoundId { get; set; }
    }
}
