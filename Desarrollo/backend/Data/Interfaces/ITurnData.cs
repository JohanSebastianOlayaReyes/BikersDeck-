using Entity.Model;

namespace Data.Interface
{
    public interface ITurnData : IBaseModelData<Turn>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Turn turn);
    }
}
