using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.PizzaDto;

namespace Web.Controllers.Interface
{
    public interface IPizzaController : IGenericController<Dto, Pizza>
    {
        Task<IActionResult> UpdatePartial(int id, PlayersUpdateDto dto);
        Task<IActionResult> ActiveAsync(int id);
    }
}


