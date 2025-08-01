using Data.Interfaces;
using Entity.Model.Base;
using Microsoft.EntityFrameworkCore;

using static Dapper.SqlMapper;

namespace Data.Implements.BaseDate
{

    /// <summary>
    /// Clase abstracta para poder sobre escribir métodos e incluir nuevos metodos sin cambiar la Interfaz
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ABaseModelData<T> : IBaseModelData<T> where T : BaseModel
    {
    
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected ABaseModelData(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Métodos abstractos que deben ser implementados por las clases derivadas
        public abstract Task<List<T>> GetAllAsync();
        public abstract Task<T> GetByIdAsync(int id);
        public abstract Task<T> CreateAsync(T entity);
        public abstract Task<T> UpdateAsync(T entity);
        public abstract Task<bool> DeleteAsync(int id);

    }
}
