using Entity.Dtos.PizzaDto;
using Entity.Dtos.PlayersDto;
using Entity.Model;

namespace Business.Interfaces
{
    public interface IPlayerBusiness : IBaseBusiness<Players, PlayersDto>
    {

        Task<bool> UpdatePartialPlayerAsync(UpdatePlayersDto dto);
        Task<bool> DeleteLogicPlayerAsync(DeleteLogicPlayersDto dto);
        int Quantity(int QuantityPlayer);
        void RegisterPlayers(int PlayersId, string NamePlayers);
        List<string> GetPlayers(int PlayersId);
        int GetQuantity(int PlayersId);
    }
}
