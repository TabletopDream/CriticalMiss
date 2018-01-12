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
    }
}
