using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync (params object[] keys);

        Task<TEntity> GetAsync (params object[] keys);

        Task<TEntity> AddAsync (TEntity entity, params object[] keys);

        Task<TEntity> UpdateAsync (TEntity entity, params object[] keys);

        Task DeleteAsync (params object[] keys);
    }
}
