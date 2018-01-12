using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Library.Interfaces;
using CriticalMiss.WebService.Data.Models;

namespace CriticalMiss.WebService.Data.Repository.Interfaces
{
    public interface IGameBoardRepository : IRepository<IGameBoard>
    {
        IEnumerable<IGameBoard> GetBoardsForGame(TableTopGames game);
        IEnumerable<IGameBoard> GetBoardsForGame(int gameId);
    }
}
