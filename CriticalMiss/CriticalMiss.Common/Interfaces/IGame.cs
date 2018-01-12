using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IGame
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
