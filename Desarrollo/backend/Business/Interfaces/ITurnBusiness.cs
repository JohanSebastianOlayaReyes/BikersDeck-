using Entity.Model;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.TurnDto;

namespace Business.Interfaces
{
    public interface ITurnBusiness : IBaseBusiness<Turn, TurnDto>
    {
        Task<bool> UpdatePartialTurnAsync(UpdateTurnDto dto);
        Task<bool> DeleteLogicTurnAsync(DeleteLogicTurnDto dto);
    }
}
