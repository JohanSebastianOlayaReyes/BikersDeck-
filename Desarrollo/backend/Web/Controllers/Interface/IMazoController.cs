using Entity.Dtos.MazoDto;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface IMazoController : IGenericController<MazoDto, Mazo>
    {
        Task<IActionResult> UpdatePartialMazo(int id, UpdateMazoDto dto);
        Task<IActionResult> DeleteLogicMazo(int id);
    }
}
