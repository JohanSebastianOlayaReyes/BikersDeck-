using Entity.Model;

namespace Data.Interface
{
    public interface ICardData : IBaseModelData<Card>
    {
        Task<bool> ActiveAsync(int id, bool status);
        Task<bool> UpdatePartial(Card card);
    }
}
