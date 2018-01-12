using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMiss.Library.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync (int id);

        Task<IEnumerable<T>> GetAllAsync ();

        Task<T> AddAsync (T entity);

        Task<T> UpdateAsync (T entity);

        Task<T> DeleteAsync (T entity);
    }
}
