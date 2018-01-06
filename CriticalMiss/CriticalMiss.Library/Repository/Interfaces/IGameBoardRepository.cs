using CriticalMiss.Library.Interfaces;
using CriticalMiss.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Repository.Interfaces
{
    public interface IGameBoardRepository : IRepository<IGameBoard>
    {
        IEnumerable<IGameBoard> GetBoardsForGame (TabletopGame game);

        IEnumerable<IGameBoard> GetBoardsForGame (int gameId);
    }
}
