using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    interface IBoard
    {
        int Width { get; set; }
        int Height { get; set; }
        int BoardId { get; set; }
        int GameId { get; set; }
    }
}
