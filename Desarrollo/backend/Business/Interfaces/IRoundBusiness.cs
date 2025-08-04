using Entity.Model;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.RoundDto;

namespace Business.Interfaces
{
    public interface IRoundBusiness : IBaseBusiness<Round, RoundDto>
    {
        Task<bool> UpdatePartialRoundAsync(UpdateRoundDto dto);
        Task<bool> DeleteLogicRoundAsync(DeleteLogicRoundDto dto);
    }
}
