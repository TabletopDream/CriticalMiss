using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository.Interfaces
{
    public interface IGameBoardRepository : IRepository<IBoard>
    {
        Task<IEnumerable<IBoard>> GetAllForBoardAsync (string gameName);
        Task<IBoard> GetByRelativeIdAsync (string gameName, int boardId);
        Task<IBoard> AddBoardRelativeAsync (string gameName, IBoard gameBoard);
        Task<IBoard> UpdateBoardAsync (string gameName, int boardId, IBoard gameBoard);
        Task<bool> BoardExistsAsync (string gameName, int boardId);
        Task DeleteRelativeAsync (string gameName, int boardId);
    }
}
