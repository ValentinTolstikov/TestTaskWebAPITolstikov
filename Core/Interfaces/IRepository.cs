using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
    }
}
