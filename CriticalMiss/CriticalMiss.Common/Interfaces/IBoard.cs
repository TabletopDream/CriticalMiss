using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IBoard
    {
        int BoardId { get; set; }
        string BoardName { get; set; }
        int GameId { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Pixel { get; set; }
        int LocalId { get; set; }
        int ItemCount { get; set; }
    }
}
