using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamenReactNet.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        Task<int> CommitAsync();
    }
}
