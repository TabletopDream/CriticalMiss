using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class BoardItem : IBoardItem
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public bool IsToken { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public IImageAsset ImageAsset { get; set; }

        public void MoveItem(int x, int y)
        {
            XPos += x;
            YPos += y;
        }

        public void AdjustSize(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
