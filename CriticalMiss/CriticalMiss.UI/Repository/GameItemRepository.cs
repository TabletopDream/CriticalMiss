using CriticalMiss.UI.Exceptions;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Models.Interfaces;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository
{
    public class GameItemRepository : IGameItemRepository
    {
        private ILibraryHttpClientProvider _libProvider;

        public GameItemRepository(ILibraryHttpClientProvider libProvider)
        {
            _libProvider = libProvider;
        }

        async Task<IUIGameItem> IRepository<IUIGameItem>.AddAsync (IUIGameItem entity, params object[] keys)
        {
            if (keys.Length != 2)
            {
                throw new ArgumentException("Params key length not 2!");
            }

            var httpClient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var boardId = keys[1] as int?;
            var uriString = string.Format("api/games/{0}/boards/{1}/items", gameName, boardId);
            var stringContent = new StringContent(JsonConvert.SerializeObject(entity),
                                                  Encoding.UTF8,
                                                  "application/json");
            var response = await httpClient.PostAsync(uriString, stringContent);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var gameItem = JsonConvert.DeserializeObject<Item>(contentBody);

                    return gameItem;
                }
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }

        async Task IRepository<IUIGameItem>.DeleteAsync (IUIGameItem entity, params object[] keys)
        {
            var httpClient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var boardId = keys[1] as int?;
            var itemId = keys[2] as int?;
        }

        Task<IEnumerable<IUIGameItem>> IRepository<IUIGameItem>.GetAllAsync (params object[] keys)
        {
            throw new NotImplementedException();
        }

        Task<IUIGameItem> IRepository<IUIGameItem>.GetAsync (params object[] keys)
        {
            throw new NotImplementedException();
        }

        Task<IUIGameItem> IRepository<IUIGameItem>.UpdateAsync (IUIGameItem entity, params object[] keys)
        {
            throw new NotImplementedException();
        }
    }
}
