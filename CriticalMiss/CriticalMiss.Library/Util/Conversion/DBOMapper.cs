﻿using CriticalMiss.Data;
using CriticalMiss.Data.Models;
using CriticalMiss.Library.Interfaces;
using CriticalMiss.Library.Models;
using System.Collections.Generic;

namespace CriticalMiss.Library.Repository.Conversion
{
    public static class DBOMapper
    {
        public static ImageAssetDBO ImageAssetToDBO (IImageAsset asset)
        {
            var dbo = new ImageAssetDBO
            {
                AssetDescription = asset.AssetDescription,
                AssetURI = asset.AssetURI,
                ImageAssetId = asset.ImageAssetId,
                DateTimeCreated = asset.DateTimeCreated
            };

            return dbo;
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
        //ex for library to database
        public static GameBoardItemDBO GameBoardItemToDBO (IGameBoardItem item)
        {
            var itemDbo = new GameBoardItemDBO()
            {
                ItemId = item.BoardItemId,
                GameBoardId = item.GameBoardId,
                ImageAssetId = item.ImageAsset.ImageAssetId,
                Name = item.Name,
                PixelHeight = item.PixelHeight,
                PixelWidth = item.PixelWidth,
                XPosition = item.XPos,
                YPosition = item.YPos,
                IsToken = item.IsToken,
            };

            return itemDbo;
        }

        

        public static IGameBoardItem GameBoardItemDBOToModel(GameBoardItemDBO itemDbo)
        {
            var model = (IGameBoardItem)new GameBoardItem();
            model.GameBoardId = itemDbo.GameBoardId;
            model.BoardItemId = itemDbo.ItemId;
            model.Name = itemDbo.Name;
            
            model.IsToken = itemDbo.IsToken;

            // Pixel Height/Width
            model.PixelHeight = itemDbo.PixelHeight;
            model.PixelWidth = itemDbo.PixelWidth;

            model.XPos = itemDbo.XPosition;
            model.YPos = itemDbo.YPosition;

            model.ImageAsset = ImageAssetDBOToModel(itemDbo.ImageAsset);

            return model;
        }

        public static GameBoardDBO GameBoardToDBO(IGameBoard board)
        {
            var dbo = new GameBoardDBO()
            {
                GameBoardId = board.GameBoardId,
                GameId = board.GameId,
                Width = board.Width,
                Height = board.Height,
                BoardItems = new List<GameBoardItemDBO>()
            };

            foreach(var item in board.BoardItems)
            {
                dbo.BoardItems.Add(GameBoardItemToDBO(item));
            }

            return dbo;
        }

        public static IGameBoard GameBoardDBOToModel(GameBoardDBO boardDbo)
        {
            var model = (IGameBoard)new GameBoard();
            model.GameBoardId = boardDbo.GameBoardId;
            model.GameId = boardDbo.GameBoardId;

            model.Width = boardDbo.Width;
            model.Height = boardDbo.Height;

            model.BoardItems = new List<IGameBoardItem>();

            foreach(var item in boardDbo.BoardItems)
            {
                var itemModel = GameBoardItemDBOToModel(item);
                model.BoardItems.Add(itemModel);
            }

            return model;
        }

        //By Rinkal Library to Model
        //public static TabletopGame GetAllGamesToModel(Games g)
        //{
        //    var model = (ITableTopGames)new TabletopGame();

        //    model.GameId = g.GameId;
        //    model.GameName = g.GameName;
        //    model.UserName = g.UserName;
        //    model.Password = g.Password;

        //    return null;
        //    //throw new NotImplementedException();
        //}
        //By Rinkal Library to Model

        //Database to Library
        public static ITableTopGames GetGamesDBOToLibrary(Games g)
        {
            var model = (ITableTopGames)new TabletopGame();

            model.GameId = g.GameId;
            model.GameName = g.GameName;
           // model.UserName = g.UserName;
            model.Password = g.Password;

            return model;
            //throw new NotImplementedException();
        }
        //Library to Database
        public static TabletopGame GetGamesLibraryToModel(ITableTopGames games)
        {
            var model = new TabletopGame();

            model.GameId = games.GameId;
            model.GameName = games.GameName;
           // model.UserName = games.UserName;
            model.Password = games.Password;

            return model;
        }


    }
}