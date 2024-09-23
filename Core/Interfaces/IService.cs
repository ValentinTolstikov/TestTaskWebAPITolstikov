using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T GetById(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task EditAsync(T entity, int id);
    }
}
