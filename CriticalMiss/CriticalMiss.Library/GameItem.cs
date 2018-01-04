﻿using CriticalMiss.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library
{
    public class GameItem : IGameBoardItem
    {
        string IGameBoardItem.Name { get; set; }
        bool IGameBoardItem.IsToken { get; set; }
        int IGameBoardItem.PixelWidth { get; set; }
        int IGameBoardItem.PixelHeight { get; set; }
        int IGameBoardItem.XPos { get; set; }
        int IGameBoardItem.YPos { get; set; }
    }
}
