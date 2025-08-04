using Entity.Model;
using Entity.Dtos.MazoDto;
using Entity.Dtos.PizzaDto;

namespace Business.Interfaces
{
    public interface IMazoBusiness : IBaseBusiness<Mazo, MazoDto>
    {
        Task<bool> UpdatePartialMazoAsync(UpdateMazoDto dto);
        Task<bool> DeleteLogicMazoAsync(DeleteLogicMazoDto dto);
    }
}
