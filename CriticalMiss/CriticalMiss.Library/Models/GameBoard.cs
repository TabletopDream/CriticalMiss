using CriticalMiss.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class GameBoard : IGameBoard
    {
        int IGameBoard.GameBoardId { get; set; }

        int IGameBoard.Width { get; set; }

        int IGameBoard.Height { get; set; }

        ICollection<IGameBoardItem> IGameBoard.BoardItems { get; set; }
    }
}
