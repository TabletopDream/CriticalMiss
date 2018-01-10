using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Interfaces
{
    public interface ITableTopGames
    {
        int GameId { get; set; }

        //string UserName { get; set; }

        string Password { get; set; }

        string GameName { get; set; }

    }
}
