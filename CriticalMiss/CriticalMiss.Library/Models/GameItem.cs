using CriticalMiss.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Models
{
    public class GameItem : IGameBoardItem
    {
        int IGameBoardItem.BoardItemId { get; set; }
        string IGameBoardItem.Name { get; set; }
        bool IGameBoardItem.IsToken { get; set; }
        int IGameBoardItem.PixelWidth { get; set; }
        int IGameBoardItem.PixelHeight { get; set; }
        int IGameBoardItem.XPos { get; set; }
        int IGameBoardItem.YPos { get; set; }
        
        IImageAsset IGameBoardItem.ImageAsset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IGameBoard IGameBoardItem.GameBoard { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
