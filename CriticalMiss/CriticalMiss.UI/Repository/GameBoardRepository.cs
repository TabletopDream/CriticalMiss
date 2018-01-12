using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository
{
    public class GameBoardRepository : IGameBoardRepository
    {
        private IDatabaseHttpClientProvider _dbProvider;

        public GameBoardRepository(IDatabaseHttpClientProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        async Task<IBoard> IRepository<IBoard>.AddAsync (IBoard entity)
        {
            throw new NotImplementedException();
        }

        async Task<IBoard> IRepository<IBoard>.DeleteAsync (IBoard entity)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<IBoard>> IRepository<IBoard>.GetAllAsync ()
        {
            var httpClient = _dbProvider.DatabaseConnection;

            var response = await httpClient.GetAsync("/api/boards");

            if (response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();
                    var boardList = JsonConvert.DeserializeObject<List<IBoard>>(contentBody);

                    return boardList;
                }
            }

            return null;
        }

        async Task<IBoard> IRepository<IBoard>.GetByIdAsync (int id)
        {
            var httpClient = _dbProvider.DatabaseConnection;

            var response = await httpClient.GetAsync("/api/boards/" + id);

            if (response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();

                    var board = JsonConvert.DeserializeObject<IBoard>(contentBody);

                    return board;
                }
            }

            return null;
        }

        async Task<IBoard> IRepository<IBoard>.UpdateAsync (IBoard entity)
        {
            throw new NotImplementedException();
        }

        //public class GameBoardItemDBOComparer : IEqualityComparer<GameBoardItemDBO>
        //{
        //    bool IEqualityComparer<GameBoardItemDBO>.Equals (GameBoardItemDBO x, GameBoardItemDBO y)
        //    {
        //        return (x.ItemId == y.ItemId);
        //    }

        //    int IEqualityComparer<GameBoardItemDBO>.GetHashCode (GameBoardItemDBO obj)
        //    {
        //        return obj.GetHashCode();
        //    }
        //}
    }
}
