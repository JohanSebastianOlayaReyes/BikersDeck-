using Entity.Model;

namespace Data.Interface
{
    public interface IGameData : IBaseModelData<Game>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Game game);
    }
}
