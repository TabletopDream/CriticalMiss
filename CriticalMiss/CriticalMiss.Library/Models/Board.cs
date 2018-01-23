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
        public string GameName { get; set; }
        public int Pixel { get; set; }
        public int LocalId { get; set; }
        public int ItemCount { get; set; }
        public string BoardName { get; set; }

        public Board()
        {

        }

        public Board(int width, int height, int id, string name)
        {
            GameName = name;
            Width = width;
            Height = height;
            LocalId = id;
            ItemCount = 0;
            Pixel = 70;
        }

        public bool ItemCounter() // determines if amount of pieces on the board is less than the max before another is allowed to be added
        {
            if (ItemCount < 20)
            {
                ItemCount++;
                return true;
            }

            return false;
        }

        //public void AddItem()
        //{
        //    var count = ItemCounter();

        //    if (count == true)
        //    {
        //        BoardItem Item = new BoardItem(ItemCount);
        //    }
        //}

        public void DeleteItem()
        {
            ItemCount--; 
        }
    }
}
