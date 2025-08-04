using Business.Interfaces;
using Entity.Dtos.ClienteDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class GameController : GenericController<GameDto, Game>, IGameController
    {
        private readonly IGameBusiness _gameBusiness;

        public GameController(IGameBusiness gameBusiness, ILogger<GameController> logger)
            : base(gameBusiness, logger)
        {
            _gameBusiness = gameBusiness;
        }

        protected override int GetEntityId(GameDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialGame(int id, [FromBody] UpdateGameDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _gameBusiness.UpdatePartialGameAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Game: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Game: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicGame(int id)
        {
            try
            {
                var dto = new DeleteLogicGameDto { Id = id, Status = false };
                var result = await _gameBusiness.DeleteLogicGameAsync(dto);
                if (!result)
                    return NotFound($"Game con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Game: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Game: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
