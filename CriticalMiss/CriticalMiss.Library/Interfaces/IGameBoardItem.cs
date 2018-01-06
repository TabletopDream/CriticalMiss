using CriticalMiss.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Interfaces
{
    public interface IGameBoardItem
    {
        int BoardItemId { get; set; }

        IGameBoard GameBoard { get; set; }

        /// <summary>
        /// The user-assigned name for this board item. This name property
        /// can be used by the application user to differentiate between
        /// similar board items.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The image asset the board item uses to display on the game board.
        /// </summary>
        IImageAsset ImageAsset { get; set; }

        /// <summary>
        /// Bool flag to determine if the board item is a token.
        /// 
        /// Token types can have special/different properties and interactions
        /// than a board background image.
        /// </summary>
        bool IsToken { get; set; }

        /// <summary>
        /// The drawable width of this item, in arbitrary pixels.
        /// </summary>
        int PixelWidth { get; set; }

        /// <summary>
        /// The drawable height of this item, in arbitrary pixels.
        /// </summary>
        int PixelHeight { get; set; }

        /// <summary>
        /// The X position of this item, in arbitrary pixels.
        /// </summary>
        int XPos { get; set; }

        /// <summary>
        /// The y position of this item, in arbitrary pixels.
        /// </summary>
        int YPos { get; set; }
    }
}
