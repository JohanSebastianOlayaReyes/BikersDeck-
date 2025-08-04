using Entity.Model;

namespace Data.Interface
{
    public interface IMazoData : IBaseModelData<Mazo>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Mazo mazo);
    }
}
