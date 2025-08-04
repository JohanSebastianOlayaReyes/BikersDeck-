using Business.Interfaces;
using Entity.Dtos.PedidoDto;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.RoomPlayersDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class RoomPlayersController : GenericController<RoomPlayersDto, RoomPlayers>, IRoomPlayersController
    {
        private readonly IRoomPlayersBusiness _roomPlayersBusiness;

        public RoomPlayersController(IRoomPlayersBusiness roomPlayersBusiness, ILogger<RoomPlayersController> logger)
            : base(roomPlayersBusiness, logger)
        {
            _roomPlayersBusiness = roomPlayersBusiness;
        }

        protected override int GetEntityId(RoomPlayersDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialRoomPlayers(int id, [FromBody] UpdateRoomPlayersDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _roomPlayersBusiness.UpdatePartialRoomPlayersAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente RoomPlayers: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente RoomPlayers: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicRoomPlayers(int id)
        {
            try
            {
                var dto = new DeleteLogicRoomPlayersDto { Id = id, Status = false };
                var result = await _roomPlayersBusiness.DeleteLogicRoomPlayerAsync(dto);
                if (!result)
                    return NotFound($"RoomPlayers con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente RoomPlayers: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente RoomPlayers: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
