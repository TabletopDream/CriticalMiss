using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace CriticalMiss.UI.Repository
{
    public class GameRepository : IGameRepository
    {
        private IDatabaseHttpClientProvider _dbProvider;

        public GameRepository(IDatabaseHttpClientProvider dbprovider)
        {
            _dbProvider = dbprovider;
        }

        Task<IGame> IRepository<IGame>.AddAsync (IGame entity)
        {
            throw new NotImplementedException();
        }

        Task<IGame> IRepository<IGame>.DeleteAsync (IGame entity)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<IGame>> IRepository<IGame>.GetAllAsync ()
        {
            var httpClient = _dbProvider.DatabaseConnection;

            var response =await httpClient.GetAsync("");
            if (response != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentbody = await content.ReadAsStringAsync();
                    var gamelist = JsonConvert.DeserializeObject<List<IGame>>(contentbody);

                    return gamelist;
                }
            }
            return null;
        }

        async Task<IGame> IRepository<IGame>.GetByIdAsync (int id)
        {
            var httpclient = _dbProvider.DatabaseConnection;
            var response = await httpclient.GetAsync("" + id);

            if (response.Content!=null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentbody = await content.ReadAsStringAsync();
                    var board = JsonConvert.DeserializeObject<IGame>(contentbody);

                    return board;
                }
            }
            return null;
        }
        Task<IGame> IRepository<IGame>.UpdateAsync (IGame entity)
        {
            throw new NotImplementedException();
        }
    }
}
