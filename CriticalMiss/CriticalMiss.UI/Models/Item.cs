using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Models
{
    public class Item : IUIGameItem
    {
        public int LocalId { get; set ; }
        public string Name { get ; set; }
        public bool IsToken { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int XPos { get; set ; }
        public int YPos { get ; set; }
        public IImageAsset ImageAsset { get ; set; }
    }
}
