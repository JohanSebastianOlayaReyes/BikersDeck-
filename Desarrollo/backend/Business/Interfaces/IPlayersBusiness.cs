using Entity.Dtos.PizzaDto;
using Entity.Dtos.PlayersDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IPlayerBusiness : IBaseBusiness<Players, PlayersDto>
    {

        Task<bool> UpdatePartialPlayerAsync(UpdatePlayersDto dto);
        Task<bool> DeleteLogicPlayerAsync(DeleteLogicPlayersDto dto);
    }
}
