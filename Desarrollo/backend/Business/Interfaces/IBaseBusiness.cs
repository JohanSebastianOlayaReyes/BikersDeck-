using Entity.Dto;
using Entity.Dtos.Base;
using Entity.Model;
using Entity.Model.Base;

namespace Business.Interfaces
{
    public interface IBaseBusiness<T, D> where T : BaseModel where D : BaseDto

    {
        Task<List<D>> GetAllAsync();

        Task<D> GetByIdAsync(int id);

        Task<D> CreateAsync(D dto);

        Task<D> UpdateAsync(D dto);

        Task<bool> DeleteAsync(int id);
    }
}