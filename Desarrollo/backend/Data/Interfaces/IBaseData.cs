using Entity.Model.Base;

namespace Data.Interface
{

    public interface IBaseModelData<T> where T : BaseModel
    {

        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
    }
}