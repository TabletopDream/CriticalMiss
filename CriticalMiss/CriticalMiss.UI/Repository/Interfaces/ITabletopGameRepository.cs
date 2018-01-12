using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.UI.Repository.Interfaces
{
    public interface ITabletopGameRepository : IRepository<IGame>
    {
        //IEnumerable<ITableTopGames> GetGameByUsername(string username);
    }
}
