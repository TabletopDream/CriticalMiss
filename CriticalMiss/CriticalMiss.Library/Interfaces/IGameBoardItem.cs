using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Interfaces
{
    public interface IGameBoardItem
    {
        int BoardItemId { get; set; }

        string Name { get; set; }

        IImageAsset ImageAsset { get; set; }

        bool IsToken { get; set; }

        int PixelWidth { get; set; }

        int PixelHeight { get; set; }

        int XPos { get; set; }

        int YPos { get; set; }
    }
}
