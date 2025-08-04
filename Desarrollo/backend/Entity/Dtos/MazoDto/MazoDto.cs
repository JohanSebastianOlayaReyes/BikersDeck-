using Entity.Dtos.Base;
using Entity.Model;

namespace Entity.Dtos.PizzaDto
{
    public class MazoDto : GenericDto
    {
        public int QuantityCards { get; set; }
        public int CardId { get; set; }
    }
}
