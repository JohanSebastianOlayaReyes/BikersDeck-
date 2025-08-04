using Entity.Dtos.PizzaDto;
using Entity.Dtos.PlayersDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IPlayersController : IGenericController<PlayersDto, Players>
    {
        Task<IActionResult> UpdatePartialPlayers(int id, UpdatePlayersDto dto);
        Task<IActionResult> DeleteLogicPlayers(int id);
    }
}
