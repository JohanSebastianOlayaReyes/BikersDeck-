using Business.Interfaces;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.TurnDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class TurnController : GenericController<TurnDto, Turn>, ITurnController
    {
        private readonly ITurnBusiness _turnBusiness;

        public TurnController(ITurnBusiness turnBusiness, ILogger<TurnController> logger)
            : base(turnBusiness, logger)
        {
            _turnBusiness = turnBusiness;
        }

        protected override int GetEntityId(TurnDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialTurn(int id, [FromBody] UpdateTurnDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _turnBusiness.UpdatePartialTurnAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Turn: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Turn: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicTurn(int id)
        {
            try
            {
                var dto = new DeleteLogicTurnDto { Id = id, Status = false };
                var result = await _turnBusiness.DeleteLogicTurnAsync(dto);
                if (!result)
                    return NotFound($"Turn con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Turn: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Turn: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
