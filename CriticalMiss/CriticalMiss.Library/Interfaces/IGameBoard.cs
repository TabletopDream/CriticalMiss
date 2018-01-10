using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Interfaces
{
    public interface IGameBoard
    {
        /// <summary>
        /// Unique integer ID for the game board.
        /// </summary>
        int GameBoardId { get; set; }

        /// <summary>
        /// The unique ID of the game this board belongs to.
        /// </summary>
        int GameId { get; set; }

        /// <summary>
        /// Width of the game board, in tiles. The size of tiles are arbitrary,
        /// and depend solely upon the higher (UI) implementation's definition
        /// of what is a tile.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Height of the game board, in tiles. The size of tiles are
        /// arbitrary, and depend solely upon the higher (UI) implementation's
        /// definition of what is a tile.
        /// </summary>
        int Height { get; set; }

        ICollection<IGameBoardItem> BoardItems { get; set; }
    }
}
