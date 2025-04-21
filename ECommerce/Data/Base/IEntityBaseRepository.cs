using ECommerce.Models;
using System.Linq.Expressions;

namespace ECommerce.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(Func<object, object> value);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include);
        Task<T> GetByIdAsync(int id);

        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChanges();

    }
}
