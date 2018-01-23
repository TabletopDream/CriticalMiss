using CriticalMiss.Common.Interfaces;
using CriticalMiss.Common.Util;
using CriticalMiss.UI.Models.Interfaces;
using Newtonsoft.Json;
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
        public double Width { get; set; }
        public double Height { get; set; }
        public int XPos { get; set ; }
        public int YPos { get ; set; }

        [JsonConverter(typeof(InterfaceConverter<ImageAsset>))]
        public IImageAsset ImageAsset { get ; set; }
    }
}
