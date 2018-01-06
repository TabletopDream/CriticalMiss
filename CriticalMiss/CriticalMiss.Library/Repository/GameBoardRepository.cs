using CriticalMiss.Data;
using CriticalMiss.Library.Interfaces;
using CriticalMiss.Library.Models;
using CriticalMiss.Library.Repository.Conversion;
using CriticalMiss.Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CriticalMiss.Library.Repository
{
    public class GameBoardRepository : IGameBoardRepository
    {
        private CriticalMissDbContext _context;

        public GameBoardRepository(CriticalMissDbContext context)
        {
            _context = context;
        }

        void IRepository<IGameBoard>.Add (IGameBoard entity)
        {
            var gameBoardDbo = new GameBoardDBO()
            {
                //GameId = entity.GameId
                Height = entity.Height,
                Width = entity.Width
            };

            _context.Add(gameBoardDbo);
            _context.SaveChanges();
        }

        void IRepository<IGameBoard>.Delete (IGameBoard entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot delete null game board!");
            }

            var dbo = _context.GameBoards.Find(entity.GameBoardId);

            if (dbo == null)
            {
                throw new InvalidOperationException("Cannot delete nonexistent entity!");
            }

            _context.Remove(dbo);
            
        }

        IEnumerable<IGameBoard> IRepository<IGameBoard>.GetAll ()
        {
            return _context.GameBoards.AsEnumerable().Select(g =>
            {
                return DBOMapper.GameBoardDBOToModel(g);
            });
        }

        IEnumerable<IGameBoard> IGameBoardRepository.GetBoardsForGame (TabletopGame game)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IGameBoard> IGameBoardRepository.GetBoardsForGame (int gameId)
        {
            return _context.GameBoards.Include(g => g.BoardItems)
                                      .Where(g => g.GameId == gameId)
                                      .AsEnumerable()
                                      .Select(g =>
                                      {
                                          return DBOMapper.GameBoardDBOToModel(g);
                                      });
        }

        IGameBoard IRepository<IGameBoard>.GetById (int id)
        {
            var dbo = _context.GameBoards.Find(id);

            if (dbo != null)
            {
                return DBOMapper.GameBoardDBOToModel(dbo);
            }

            throw new InvalidOperationException("Cannot get nonexistent board!");
        }

        void IRepository<IGameBoard>.Update (IGameBoard entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Board to update may not be null!");
            }

            var dbo = _context.GameBoards.Include(g => g.BoardItems)
                                         .SingleOrDefault(g => g.GameBoardId == entity.GameBoardId);
            if (dbo == null)
            {
                throw new InvalidOperationException("Cannot update nonexistent game board!");
            }

            var newDbo = DBOMapper.GameBoardToDBO(entity);
            var boardItemDbos = entity.BoardItems?.Select(item =>
            {
                return DBOMapper.GameBoardItemToDBO(item);
            });

            dbo.Height = newDbo.Height;
            dbo.Width = newDbo.Width;

            dbo.BoardItems = (dbo.BoardItems ?? new List<GameBoardItemDBO>())
                             .Join(boardItemDbos,
                                   outer => outer.ItemId,
                                   inner => inner.ItemId,
                                   (outer, inner) =>
                                   {
                                       outer.ImageAssetId = inner.ImageAssetId;
                                       outer.Name = inner.Name;
                                       outer.PixelHeight = inner.PixelHeight;
                                       outer.PixelWidth = inner.PixelWidth;
                                       outer.XPosition = inner.XPosition;
                                       outer.YPosition = inner.YPosition;
                                       return outer;
                                   })
                                   .Union(newDbo.BoardItems, new GameBoardItemDBOComparer())
                                   .ToList();
        }

        public class GameBoardItemDBOComparer : IEqualityComparer<GameBoardItemDBO>
        {
            bool IEqualityComparer<GameBoardItemDBO>.Equals (GameBoardItemDBO x, GameBoardItemDBO y)
            {
                return (x.ItemId == y.ItemId);
            }

            int IEqualityComparer<GameBoardItemDBO>.GetHashCode (GameBoardItemDBO obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
