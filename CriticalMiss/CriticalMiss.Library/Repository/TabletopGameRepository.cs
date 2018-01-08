using CriticalMiss.Library.Models;
using CriticalMiss.Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CriticalMiss.Data;
using CriticalMiss.Data.Models;
using System.Linq;
using CriticalMiss.Library.Repository.Conversion;
using Microsoft.EntityFrameworkCore;

namespace CriticalMiss.Library.Repository
{
    public class TabletopGameRepository : ITabletopGameRepository
    {
        private CriticalMissDbContext _context;

        public TabletopGameRepository(CriticalMissDbContext context)
        {
            _context = context;
        }
        public void Add(TabletopGame entity)
        {
            var dobgames = new Games()
            {
                UserName = entity.UserName,
                GameName = entity.GameName,
                Password = entity.Password
            };

            _context.Add(dobgames);
            _context.SaveChanges();
        }

        public void Delete(TabletopGame entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TabletopGame> GetAll()
        {
            return _context.games.AsEnumerable().Select(g =>
            {
                return DBOMapper.GetAllGamesToModel(g);
            });

        }
        public IEnumerable<TabletopGame> GetAll(string username)
        {
            return _context.games.AsEnumerable().Where(g => g.UserName == username).
                 AsEnumerable().
                 Select(g =>
                 {
                     return DBOMapper.GetAllGamesToModel(g);
                 });
        }

        public TabletopGame GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TabletopGame entity)
        {
            throw new NotImplementedException();
        }
    }
}
