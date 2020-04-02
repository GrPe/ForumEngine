using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumEngine.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Type of stored object</typeparam>
    /// <typeparam name="R">Type of object id</typeparam>
    public interface IRepository<T, R>
    {
        Task<T> GetByIdAsync(R id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task RemoveAsync(R id);
    }
}
