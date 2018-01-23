using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.WebService.Data.Models;
using CriticalMiss.Common.Interfaces;
namespace CriticalMiss.WebService.Data.Repository.Interfaces
{
    public interface IGameBoardRepository : IRepository<IGame>
    {

        //Made change from IGameBoard to IGame   : By Rinkal

        IEnumerable<IGame> GetBoardsForGame(TableTopGames game);
        IEnumerable<IGame> GetBoardsForGame(int gameId);

    }
}
