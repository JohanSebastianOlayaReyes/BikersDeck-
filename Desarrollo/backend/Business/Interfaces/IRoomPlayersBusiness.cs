using Entity.Dtos.PizzaDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IPlayersBusiness : IBaseBusiness<Players, PlayersDto>
    {

        Task<bool> UpdatePartialAsync(PlayersUpdateDto dto);
        Task<bool> ActiveAsync(RoomPlayersaActiveDto dto);

    }
}
