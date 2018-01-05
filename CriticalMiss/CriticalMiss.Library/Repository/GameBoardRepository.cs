using CriticalMiss.Data;
using CriticalMiss.Library.Interfaces;
using CriticalMiss.Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        void IRepository<IGameBoard>.Delete (IGameBoard entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IGameBoard> IRepository<IGameBoard>.GetAll ()
        {
            throw new NotImplementedException();
        }

        IGameBoard IRepository<IGameBoard>.GetById (int id)
        {
            throw new NotImplementedException();
        }

        void IRepository<IGameBoard>.Update (IGameBoard entity)
        {
            throw new NotImplementedException();
        }
    }
}
