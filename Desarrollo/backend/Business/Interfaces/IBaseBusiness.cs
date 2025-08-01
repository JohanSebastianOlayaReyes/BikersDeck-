using Entity.Dtos.Base;
using Entity.Model.Base;

namespace Business.Interfaces
{
    public interface IBaseBusiness<T, D> where T : BaseModel where D : BaseDto

    {
        Task<D> GetByIdAsync(int id);
        Task<D> UpdateAsync(D dto);
        Task<bool> ActiveAsync(int id);
    }
}