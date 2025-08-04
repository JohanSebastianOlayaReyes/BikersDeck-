using Entity.Dtos.PizzaDto;
using Entity.Dtos.TurnDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface ITurnController : IGenericController<TurnDto, Turn>
    {
        Task<IActionResult> UpdatePartialTurn(int id, UpdateTurnDto dto);
        Task<IActionResult> DeleteLogicTurn(int id);
    }
}
