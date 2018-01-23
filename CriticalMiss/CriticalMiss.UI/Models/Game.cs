using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Models
{
    public class Game : IUIGame
    {
        public string GameName { get; set; }
        public string Password { get; set; }

        public bool ShouldSerializePassword () => Password != null;
    }
}
