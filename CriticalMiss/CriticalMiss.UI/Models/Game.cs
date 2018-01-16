using CriticalMiss.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Models
{
    public class Game : IGame
    {
        public string GameName { get; set; }
        public int GameId { get; set; }
        public string Password { get; set; }
    }
}
