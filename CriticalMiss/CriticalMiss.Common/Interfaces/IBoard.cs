using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IBoard
    {
        string GameName { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Pixel { get; set; }
        int LocalId { get; set; }
    }
}
