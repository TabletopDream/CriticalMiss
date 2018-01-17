using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository.Interfaces
{
    public interface IGameBoardRepository
    {
        Task<IEnumerable<IBoard>> GetBoardsForGameAsync (string gameName);
        Task<IBoard> GetByRelativeIdAsync (string gameName, int boardId);
        Task<bool> BoardExistsAsync (string gameName, int boardId);
        Task<IBoard> AddAsync (string gameName, IBoard entity);
        Task<IBoard> UpdateAsync (string gameName, int boardId, IBoard entity);
        Task DeleteAsync (string gameName, int boardId);
    }
}
