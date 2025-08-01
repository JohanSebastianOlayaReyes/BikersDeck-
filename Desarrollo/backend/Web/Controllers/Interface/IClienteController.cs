using Entity.Dtos.ClienteDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IClienteController : IGenericController<GameDto, Cliente>
    {
        Task<IActionResult> UpdatePartial(int id,  GameUpdateDto dto);
        Task<IActionResult> DeleteLogic(int id);
    }
}


