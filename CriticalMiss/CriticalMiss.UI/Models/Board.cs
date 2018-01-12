using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Common.Interfaces;

namespace CriticalMiss.UI.Models
{
    public class Board : IBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int BoardId { get; set; }
        public int GameId { get; set; }
        public int PixelCount { get; set; }
    }
}
