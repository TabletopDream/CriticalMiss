using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class Game : IGame
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<IBoard> Boards { get; set; }

        public Game(string name)
        {
            Name = name;
            Boards = new List<IBoard>();
        }

        public void CreateBoard(int w, int h)
        {
            var c = Boards.Count;

            Boards.Add(new Board(w, h, c));
        }
    }
}
