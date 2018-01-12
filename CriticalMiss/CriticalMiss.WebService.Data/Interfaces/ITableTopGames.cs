using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.WebService.Data.Interfaces
{
    public interface ITableTopGames
    {
        int GameId { get; set; }

        //string UserName { get; set; }

        string Password { get; set; }

        string GameName { get; set; }
    }
}
