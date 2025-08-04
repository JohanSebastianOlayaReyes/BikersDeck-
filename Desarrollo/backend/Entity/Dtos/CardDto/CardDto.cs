using Entity.Dtos.Base;

namespace Entity.Dtos.PizzaDto
{
    public class CardDto : GenericDto
    {
        public string photo { get; set; }
        public string Name { get; set; }
        public int Displacement { get; set; }
        public decimal power { get; set; }
        public decimal Torque { get; set; }
        public int speed { get; set; }
        public int model { get; set; }
        public int CylinderNumber { get; set; }

    }
}
