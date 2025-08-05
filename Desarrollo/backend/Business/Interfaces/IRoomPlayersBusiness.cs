using Entity.Model;
using Entity.Dtos.RoomPlayersDto;
using Entity.Dtos.PedidoDto;
using Entity.Dtos.PizzaDto;

namespace Business.Interfaces
{
    public interface IRoomPlayersBusiness : IBaseBusiness<RoomPlayers, RoomPlayersDto>
    {
        Task<bool> UpdatePartialRoomPlayersAsync(UpdateRoomPlayersDto dto);
        Task<bool> DeleteLogicRoomPlayerAsync(DeleteLogicRoomPlayersDto dto);
    }
}