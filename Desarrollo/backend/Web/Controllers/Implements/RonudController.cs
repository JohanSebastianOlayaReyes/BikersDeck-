using Business.Interfaces;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.RoundDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class RoundController : GenericController<RoundDto, Round>, IRoundController
    {
        private readonly IRoundBusiness _roundBusiness;

        public RoundController(IRoundBusiness roundBusiness, ILogger<RoundController> logger)
            : base(roundBusiness, logger)
        {
            _roundBusiness = roundBusiness;
        }

        protected override int GetEntityId(RoundDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialRound(int id, [FromBody] UpdateRoundDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _roundBusiness.UpdatePartialRoundAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Round: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Round: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicRound(int id)
        {
            try
            {
                var dto = new DeleteLogicRoundDto { Id = id, Status = false };
                var result = await _roundBusiness.DeleteLogicRoundAsync(dto);
                if (!result)
                    return NotFound($"Round con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Round: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Round: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
