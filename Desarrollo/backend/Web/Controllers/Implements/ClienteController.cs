using Business.Interfaces;
using Entity.Dtos.ClienteDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.Controllers.Interface;

namespace Web.Controllers.Implements;

[Route("api/[controller]")]
public class ClienteController : GenericController<GameDto, Cliente>, IClienteController
{
    private readonly IClienteBusiness _clienteBusiness;
    public ClienteController(IClienteBusiness clienteBusiness, ILogger<ClienteController> logger)
        : base(clienteBusiness, logger)
    {
        _clienteBusiness = clienteBusiness;
    }

    protected override int GetEntityId(GameDto dto) 
    {
        return dto.Id;
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdatePartial(int id, [FromBody] GameUpdateDto dto)
    {
        if (dto == null || dto.Id <= 0)
            return BadRequest(new { error = "Datos inválidos o ID faltante." });

        var result = await _clienteBusiness.UpdatePartialAsync(dto);

        if (!result)
            return NotFound(new { error = $"No se encontró el ... con ID {dto.Id} o no se realizaron cambios." });

        return Ok(new { message = "... actualizado parcialmente con éxito." });
    }

    [HttpDelete("logic/{id}")]
    public async Task<IActionResult> DeleteLogic(int id)
    {
        try
        {
            var dto = new GameActiveDto { Id = id, Active = false };
            var result = await _clienteBusiness.ActiveAsync(dto);

            if (!result)
                return NotFound($"Doctor con ID {id} no encontrado");

            return Ok(new { Success = true });
        }
        catch (ValidationException ex)
        {
            _logger.LogError($"Error de validación al eliminar lógicamente ..: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al eliminar lógicamente el .. con ID {id}: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }



}
