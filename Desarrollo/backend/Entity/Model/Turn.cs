using Entity.Model.Base;
// Turno
namespace Entity.Model
{
    public class Turn : GenericBase
    {
        public DateTime Time { get; set; }
        public  string Attribute { get; set; }  
        public Round Round { get; set; }
        public int RoundId { get; set; }
    }
}
