    using CriticalMiss.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class TabletopGame : ITableTopGames
    {
   
        public int GameId { get; set; }


       // public string UserName { get; set; }


        public string GameName { get; set; }


        public string Password { get; set; }
    }
}
