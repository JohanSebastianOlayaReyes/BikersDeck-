using Entity.Dtos.Base;

namespace Entity.Dtos.MazoDto
{
    public class UpdateMazoDto : GenericDto
    {
        public int QuantityCards { get; set; }
        public int CardId { get; set; }
    }
}