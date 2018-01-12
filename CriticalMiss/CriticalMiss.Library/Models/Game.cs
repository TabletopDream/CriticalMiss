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

        public Game(string name)
        {
            Name = name;
        }

        
    }
}
