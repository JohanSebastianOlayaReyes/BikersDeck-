using Entity.Model;

namespace Data.Interface
{
    public interface IRoundData : IBaseModelData<Round>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Round round);
    }
}
