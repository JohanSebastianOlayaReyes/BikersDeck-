using Back_end.Context;
using Entity.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Implements.BaseData
{
    public class BaseModelData<T> : ABaseModelData<T> where T : BaseModel
    {
        public BaseModelData(ApplicationDbContext context) : base(context)
        {
        }

        // Implementación completa de los métodos abstractos
        public override async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public override async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public override async Task<T> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = null;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<T> UpdateAsync(T entity)
        {
            var existing = await _context.Set<T>().FindAsync(entity.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existing;
        }





        public override async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}