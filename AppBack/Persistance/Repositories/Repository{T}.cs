using AppBack.Core.Application.Interfaces;
using AppBack.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppBack.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly MyAppContext _appContext;

        public Repository(MyAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this._appContext.Set<T>().AddAsync(entity);
            await this._appContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._appContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this._appContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this._appContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this._appContext.Set<T>().Remove(entity);
            await this._appContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this._appContext.Set<T>().Update(entity);
            await this._appContext.SaveChangesAsync();
        }
    }
}
