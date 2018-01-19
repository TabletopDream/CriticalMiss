using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models.Interfaces;

namespace CriticalMiss.UI.Models
{
    public class Board : IUIGameBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int BoardId { get; set; }
        public int GameId { get; set; }
        public int Pixel { get; set; }
        public int LocalId { get; set; }
        public int ItemCount { get; set; }
        public string BoardName { get; set; }
        public string GameName { get; set; }
    }
}
