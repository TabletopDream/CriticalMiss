using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.Common.Interfaces;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository
{
    public class TabletopGameRepository : ITabletopGameRepository
    {
        Task<IGame> IRepository<IGame>.AddAsync (IGame entity)
        {
            throw new NotImplementedException();
        }

        Task<IGame> IRepository<IGame>.DeleteAsync (IGame entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IGame>> IRepository<IGame>.GetAllAsync ()
        {
            throw new NotImplementedException();
        }

        Task<IGame> IRepository<IGame>.GetByIdAsync (int id)
        {
            throw new NotImplementedException();
        }

        Task<IGame> IRepository<IGame>.UpdateAsync (IGame entity)
        {
            throw new NotImplementedException();
        }
    }
}
