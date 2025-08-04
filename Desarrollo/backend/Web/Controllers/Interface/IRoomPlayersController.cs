using Entity.Dtos.PedidoDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IRoomPlayersController : IGenericController<RoomPlayersDto, RoomPlayers>
    {
        Task<IActionResult> UpdatePartialRoomPlayers(int id, UpdateRoomPlayersDto dto);
        Task<IActionResult> DeleteLogicRoomPlayers(int id);
    }
}
