using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly UserDBContext _dbContext;

        public Repository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { id });
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                   .Where(predicate)
                   .ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
