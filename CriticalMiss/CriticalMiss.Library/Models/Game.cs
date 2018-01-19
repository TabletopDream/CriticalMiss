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
        public string Password { get; set; }
    }
}
