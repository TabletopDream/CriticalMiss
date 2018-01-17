using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        async Task<IEnumerable<IBoard>> IRepository<IBoard>.GetAllAsync()
        {
            var httpClient = _dbProvider.DatabaseConnection;

            var response = await httpClient.GetAsync("/api/boards/");

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

        async Task<IBoard> IRepository<IBoard>.GetByIdAsync(int id)
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
        async Task<IBoard> IRepository<IBoard>.AddAsync(IBoard entity)
        {
            var httpclient = _dbProvider.DatabaseConnection;

            string content = JsonConvert.SerializeObject(entity);
            var contentdata = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpclient.PostAsync("api/games/", contentdata);

            if (response.Content != null)
            {
                return JsonConvert.DeserializeObject<IBoard>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        async Task<IBoard> IRepository<IBoard>.DeleteAsync(IBoard entity)
        {
            var httpclient = _dbProvider.DatabaseConnection;
            string content = JsonConvert.SerializeObject(entity);

            var contentdata = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await httpclient.DeleteAsync("api/games/" + entity.BoardName);
            if (response.Content != null)
            {
                return JsonConvert.DeserializeObject<IBoard>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        async Task<IBoard> IRepository<IBoard>.UpdateAsync(IBoard entity)
        {
            var httpclient = _dbProvider.DatabaseConnection;
            string content = JsonConvert.SerializeObject(entity);

            var contentdata = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpclient.PutAsync("api/games/" + entity.BoardName, contentdata);
            if (response.Content != null)
            {
                return JsonConvert.DeserializeObject<IBoard>(await response.Content.ReadAsStringAsync());
            }
            return null;
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
