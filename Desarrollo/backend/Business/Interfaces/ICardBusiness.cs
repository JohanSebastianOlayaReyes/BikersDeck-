using Entity.Model;
using Entity.Dto.Client;
using Entity.Dtos.CardDto;
using Entity.Dtos.PizzaDto;

namespace Business.Interfaces
{
    public interface ICardBusiness : IBaseBusiness<Card, CardDto>
    {
        Task<bool> UpdatePartialCardAsync(UpdateCard dto);
        Task<bool> DeleteLogicCardAsync(DeleteLogicCardDto dto);
    }
}
