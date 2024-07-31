using System.Linq.Expressions;

namespace AppBack.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByFilterAsync(Expression<Func<T,bool>> filter);
    }
}
