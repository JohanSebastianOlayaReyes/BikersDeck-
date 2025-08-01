using Entity.Dtos.Base;

namespace Entity.Dtos.PizzaDto
{
    public class MazoDto : GenericDto
    {
        public string QuantityPlayers { get; set; }
        public bool Active { get; set; }    

    }
}
