using CriticalMiss.Data;
using CriticalMiss.Data.Models;
using CriticalMiss.Library.Interfaces;
using CriticalMiss.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalMiss.Library.Repository.Conversion
{
    public static class DBOMapper
    {
        public static ImageAssetDBO ImageAssetToDBO (IImageAsset asset)
        {
            return null;
        }

        public static IImageAsset ImageAssetDBOToModel(ImageAssetDBO assetDbo)
        {
            var model = (IImageAsset)new ImageAsset();
            model.AssetDescription = assetDbo.AssetDescription;
            model.AssetURI = assetDbo.AssetURI;
            model.DateTimeCreated = assetDbo.DateTimeCreated;
            model.ImageAssetId = assetDbo.ImageAssetId;

            return model;
        }

        public static GameBoardItemDBO GameBoardItemToDBO (IGameBoardItem item)
        {
            var itemDbo = new GameBoardItemDBO()
            {
                GameBoardId = item.GameBoard.GameBoardId,
                ImageAssetId = item.ImageAsset.ImageAssetId,
                Name = item.Name,
                PixelHeight = item.PixelHeight,
                PixelWidth = item.PixelWidth,
                XPosition = item.XPos,
                YPosition = item.YPos
            };

            return itemDbo;
        }

        

        public static IGameBoardItem GameBoardItemDBOToModel(GameBoardItemDBO itemDbo)
        {
            var model = (IGameBoardItem)new GameItem();
            model.BoardItemId = itemDbo.ItemId;
            model.ImageAsset = ImageAssetDBOToModel(itemDbo.ImageAsset);
            
            return null;
        }

        public static GameBoardDBO GameBoardToDBO(IGameBoard board)
        {
            return null;
        }

        public static IGameBoard GameBoardDBOToModel(GameBoardDBO boardDbo)
        {
            return null;
        }

        //By Rinkal Library to Model
        public static TabletopGame GetAllGamesToModel(Games g)
        {
            var model = (ITableTopGames)new TabletopGame();

            model.GameId = g.GameId;
            model.GameName = g.GameName;
            model.UserName = g.UserName;
            model.Password = g.Password;

            return null;
            //throw new NotImplementedException();
        }

        public static ITableTopGames GetGamesToModel(Games g)
        {
            var model = (ITableTopGames)new TabletopGame();

            model.GameId = g.GameId;
            model.GameName = g.GameName;
            model.UserName = g.UserName;
            model.Password = g.Password;

            return null;
            //throw new NotImplementedException();
        }


    }
}
