using Entity.Dtos.ClienteDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IGameController : IGenericController<GameDto, Game>
    {
        Task<IActionResult> UpdatePartialGame(int id, UpdateGameDto dto);
        Task<IActionResult> DeleteLogicGame(int id);
    }
}
