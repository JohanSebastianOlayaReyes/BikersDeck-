using Business.Interfaces;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]
public class PizzaController : GenericController<Dto, Pizza>, IPizzaController
{
    private readonly IPizzaBusiness _pizzaBusiness;
    public PizzaController(IPizzaBusiness pizzaBusiness, ILogger<PizzaController> logger)
        : base(pizzaBusiness, logger)
    {
        _pizzaBusiness = pizzaBusiness;
    }

    protected override int GetEntityId(Dto dto)
    {
        return dto.Id;
    }

    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> ActiveAsync(int id)
    {
        try
        {
            var dto = new PizzaActiveDto { Id = id, Active = false };
            var result = await _pizzaBusiness.ActiveAsync(dto);

            if (!result)
                return NotFound($".... con ID {id} no encontrado");

            return Ok(new { Success = true });
        }
        catch (ValidationException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente ...: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el ... con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }


    [HttpPatch("update")]
    public async Task<IActionResult> UpdatePartial(int id, [FromBody] PlayersUpdateDto dto)
    {
        if (dto == null || dto.Id <= 0)
            return BadRequest(new { error = "Datos inválidos o ID faltante." });

        var result = await _pizzaBusiness.UpdatePartialAsync(dto);

        if (!result)
            return NotFound(new { error = $"No se encontró el ... con ID {dto.Id} o no se realizaron cambios." });

        return Ok(new { message = ".... actualizado parcialmente con éxito." });
    }



}