using Business.Interfaces;
using Entity.Dtos.MazoDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class MazoController : GenericController<MazoDto, Mazo>, IMazoController
    {
        private readonly IMazoBusiness _mazoBusiness;

        public MazoController(IMazoBusiness mazoBusiness, ILogger<MazoController> logger)
            : base(mazoBusiness, logger)
        {
            _mazoBusiness = mazoBusiness;
        }

        protected override int GetEntityId(MazoDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialMazo(int id, [FromBody] UpdateMazoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _mazoBusiness.UpdatePartialMazoAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Mazo: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Mazo: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicMazo(int id)
        {
            try
            {
                var dto = new DeleteLogicMazoDto { Id = id, Status = false };
                var result = await _mazoBusiness.DeleteLogicMazoAsync(dto);
                if (!result)
                    return NotFound($"Mazo con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Mazo: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Mazo: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
