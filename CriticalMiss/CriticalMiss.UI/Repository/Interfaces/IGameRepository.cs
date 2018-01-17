using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<IGame>> GetAllAsync ();
        Task<IGame> GetByNameAsync (string gameName);
        Task<IGame> AddAsync (IGame entity);
        Task<IGame> UpdateAsync (string gameName, IGame entity);
        Task DeleteAsync (string gameName);
    }
}
