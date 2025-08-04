using Entity.Dtos.PlayersDto;
using Entity.Model;

namespace Data.Interface
{
    public interface IPlayerData : IBaseModelData<Players>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Players player);
    }
}
