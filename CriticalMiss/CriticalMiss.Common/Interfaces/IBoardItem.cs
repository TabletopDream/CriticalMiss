using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Common.Interfaces
{
    public interface IBoardItem
    {
        int LocalId { get; set; }

        string Name { get; set; }

        bool IsToken { get; set; }

        double Width { get; set; }

        double Height { get; set; }

        int XPos { get; set; }

        int YPos { get; set; }

        IImageAsset ImageAsset { get; set; }
    }
}
