using Business.Interfaces;
using Entity.Dto.Client;
using Entity.Dtos.CardDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class CardController : GenericController<CardDto, Card>, ICardController
    {
        private readonly ICardBusiness _cardBusiness;

        public CardController(ICardBusiness cardBusiness, ILogger<CardController> logger)
            : base(cardBusiness, logger)
        {
            _cardBusiness = cardBusiness;
        }

        protected override int GetEntityId(CardDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialCard(int id, [FromBody] UpdateCard dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _cardBusiness.UpdatePartialCardAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Card: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Card: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicCard(int id)
        {
            try
            {
                var dto = new DeleteLogicCardDto { Id = id, Status = false };
                var result = await _cardBusiness.DeleteLogicCardAsync(dto);
                if (!result)
                    return NotFound($"Card con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Card: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Card: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
