using Entity.Dto.Client;
using Entity.Dtos.PizzaDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Interface;

namespace WebApplication1.Controllers.Interface
{
    public interface ICardController : IGenericController<CardDto, Card>
    {
        Task<IActionResult> UpdatePartialCard(int id, UpdateCard dto);
        Task<IActionResult> DeleteLogicCard(int id);
    }
}
