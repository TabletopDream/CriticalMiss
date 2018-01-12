using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class Board : IBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int BoardId { get; set; }
        public int GameId { get; set; }
        public int Pixel { get; set; }
        public List<IBoardItem> Items { get; set; }
    }
}
