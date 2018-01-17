using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class Game : IGame
    {
        public string GameName { get; set; }
        public int GameId { get; set; }

        public Game(string name)
        {
            GameName = name;
        }

        public Game(string name, bool b)
        {
            GameName = name;
            Board board = new Board(20, 20, 1);
        }


    }
}
