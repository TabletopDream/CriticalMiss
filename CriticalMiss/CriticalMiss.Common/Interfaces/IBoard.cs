using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IBoard
    {
        int Width { get; set; }
        int Height { get; set; }
        int BoardId { get; set; }
        int GameId { get; set; }
        int Pixel { get; set; }
        List<IBoardItem> Items { get; set; }
    }
}
