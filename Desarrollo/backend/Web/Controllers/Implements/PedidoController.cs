using Business.Interfaces;
using Entity.Dtos.PedidoDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]
public class PedidoController : GenericController<RoomPlayersDto, RoomPlayers>, IPedidoController
{
    private readonly IPedidoBusiness _pedidoBusiness;

    public PedidoController(IPedidoBusiness pedidoBusiness, ILogger<PedidoController> logger)
        : base(pedidoBusiness, logger)
    {
        _pedidoBusiness = pedidoBusiness;
    }

    protected override int GetEntityId(RoomPlayersDto dto)
    {
        return dto.Id;
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdatePartial(int id, [FromBody]  RoomPlayersDto dto)
    {
        if (dto == null || dto.Id <= 0)
            return BadRequest(new { error = "Datos inválidos o ID faltante." });

        var result = await _pedidoBusiness.UpdatePartialAsync(dto);

        if (!result)
            return NotFound(new { error = $"No se encontró la cita con ID {dto.Id} o no se realizaron cambios." });

        return Ok(new { message = "Cita actualizada parcialmente con éxito." });
    }
}
