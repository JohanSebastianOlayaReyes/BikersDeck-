using Entity.Model;
using Entity.Dtos.ClienteDto;

namespace Business.Interfaces
{
    public interface IGameBusiness : IBaseBusiness<Game, GameDto>
    {
        Task<bool> UpdatePartialGameAsync(UpdateGameDto dto);
        Task<bool> DeleteLogicGameAsync(DeleteLogicGameDto dto);
    }
}
