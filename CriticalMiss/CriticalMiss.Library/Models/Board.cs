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
        public int LocalId { get; set; }

        public Board(int width, int height, int id)
        {
            Width = width;
            Height = height;
            LocalId = id;
            Items = new List<IBoardItem>();
        }

        public void CreateItem()
        {
            var c = Items.Count;

            Items.Add(new BoardItem(c));
        }
    }
}
