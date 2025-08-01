using Entity.Dtos.Base;

namespace Entity.Dtos.PizzaDto
{
    public  class PizzaDto : GenericDto
    {
        public decimal Precio { get; set; }
        public bool Active { get; set; }

    }
}
