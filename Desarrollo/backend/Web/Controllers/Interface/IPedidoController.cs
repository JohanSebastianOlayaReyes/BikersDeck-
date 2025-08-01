using Entity.Dtos.PedidoDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{

    public interface IPedidoController : IGenericController<RoomPlayersDto, RoomPlayers>
    {
        Task<IActionResult> UpdatePartial(int id, RoomPlayersDto dto);

    }
}
