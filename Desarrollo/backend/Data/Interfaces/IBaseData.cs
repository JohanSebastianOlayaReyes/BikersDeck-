using Entity.Model.Base;


namespace Data.Interfaces

{
    /// <summary>
    /// Interfaz que me define los métodos generales
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public interface IBaseModelData<T> where T : BaseModel
    {
        /// <summary>
        /// Método para obtener una entidad por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Método para obtener todos las entidades
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Crea una entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Actualiza todos los valores de una entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);


        /// <summary>
        /// Eliminación concreta o absoluta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);


    }
}
