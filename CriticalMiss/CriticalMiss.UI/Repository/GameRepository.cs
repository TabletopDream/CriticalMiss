using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using CriticalMiss.UI.Models;

namespace CriticalMiss.UI.Repository
{
    public class GameRepository : IGameRepository
    {
        private IDatabaseHttpClientProvider _dbProvider;

        public GameRepository(IDatabaseHttpClientProvider dbprovider)
        {
            _dbProvider = dbprovider;
        }      

        async Task<IEnumerable<IGame>> IRepository<IGame>.GetAllAsync ()
        {
            var httpClient = _dbProvider.DatabaseConnection;

            var response =await httpClient.GetAsync("api/Games");
            if (response.Content != null)
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
        async Task<IGame> IRepository<IGame>.AddAsync(IGame entity)
        {
            var httpclient = _dbProvider.DatabaseConnection;

            string content = JsonConvert.SerializeObject(entity);
            var contentdata = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpclient.PostAsync("api/games/", contentdata);

            if (response.Content != null)
            {
                return JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
        async Task<IGame> IRepository<IGame>.UpdateAsync (IGame entity)
        {
            var httpclient = _dbProvider.DatabaseConnection;
            string content = JsonConvert.SerializeObject(entity);

            var contentdata = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await httpclient.PutAsync("api/games/" + entity.GameName, contentdata);
            if (response.Content!=null)
            {
                return JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }

        async Task<IGame> IRepository<IGame>.DeleteAsync(IGame entity)
        {

            var httpclient = _dbProvider.DatabaseConnection;
            string content = JsonConvert.SerializeObject(entity);

            var contentdata = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await httpclient.DeleteAsync("api/games/" + entity.GameName);
            if (response.Content!=null)
            {
                return JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
