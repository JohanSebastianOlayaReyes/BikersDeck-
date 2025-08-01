using Entity.Model.Base;
// Carta
namespace Entity.Model
{
    public class Card : GenericBase
    {
        public string photo { get; set; }
        public string Name { get; set; }
        public int Displacement { get; set; }
        public decimal power { get; set; }
        public decimal Torque { get; set; }
        public int speed { get; set; }
        public int model { get; set; }
        public int CylinderNumber { get; set; }
        public ICollection<Mazo> Mazo { get; set; }

    }
}
