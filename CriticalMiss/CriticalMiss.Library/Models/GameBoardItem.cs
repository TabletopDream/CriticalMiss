using CriticalMiss.Library.Interfaces;

namespace CriticalMiss.Library.Models
{
    public class GameBoardItem : IGameBoardItem
    {
        int IGameBoardItem.BoardItemId { get; set; }

        int IGameBoardItem.GameBoardId { get; set; }

        string IGameBoardItem.Name { get; set; }
        bool IGameBoardItem.IsToken { get; set; }

        int IGameBoardItem.PixelWidth { get; set; }
        int IGameBoardItem.PixelHeight { get; set; }

        int IGameBoardItem.XPos { get; set; }
        int IGameBoardItem.YPos { get; set; }

        IImageAsset IGameBoardItem.ImageAsset { get; set; }

        public GameBoardItem (int gameBoardId)
        {
            ((IGameBoardItem)this).GameBoardId = gameBoardId;
        }

        public GameBoardItem (IGameBoard gameBoard)
        {
            ((IGameBoardItem)this).GameBoardId = gameBoard.GameBoardId;
        }
    }
}
