using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IGame
    {
        string GameName { get; set; }
        
        int GameId { get; set; }

        string Password { get; set; }
    }
}
