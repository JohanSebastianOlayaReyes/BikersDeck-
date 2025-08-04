using Entity.Dtos.PizzaDto;
using Entity.Dtos.RoundDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IRoundController : IGenericController<RoundDto, Round>
    {
        Task<IActionResult> UpdatePartialRound(int id, UpdateRoundDto dto);
        Task<IActionResult> DeleteLogicRound(int id);
    }
}
