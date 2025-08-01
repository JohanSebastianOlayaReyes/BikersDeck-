using Entity.Dtos.PedidoDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IRoomPlayersBusiness : IBaseBusiness<RoomPlayers, RoomPlayersDto>
    {

        Task<bool> UpdatePartialAsync(PlayersUpdateDto dto);
        Task<bool> ActiveAsync(RoomPlayersaActiveDto dto);

    }
}
