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
        private static string _itemsCollectionUrlString = "api/games/{0}/boards/{1}/items";
        private static string _itemUrlString = "api/games/{0}/boards/{1}/items/{2}";

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
            var uriString = string.Format(_itemsCollectionUrlString, gameName, boardId);
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

        async Task IRepository<IUIGameItem>.DeleteAsync (params object[] keys)
        {
            if (keys.Length != 3)
            {
                throw new ArgumentException("Keys count not 3!");
            }

            var httpClient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var boardId = keys[1] as int?;
            var itemId = keys[2] as int?;
            var uriString = string.Format(_itemUrlString, gameName, boardId, itemId);

            var response = await httpClient.DeleteAsync(uriString);

            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }

        async Task<IEnumerable<IUIGameItem>> IRepository<IUIGameItem>.GetAllAsync (params object[] keys)
        {
            var httpClient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var boardId = keys[1] as int?;
            var uriString = string.Format(_itemsCollectionUrlString, gameName, boardId);

            var response = await httpClient.GetAsync(uriString);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var items = JsonConvert.DeserializeObject<List<Item>>(contentBody);

                    return items;
                }
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpResourceNotFoundException()
                {
                    HttpResponse = response
                };
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }

        async Task<IUIGameItem> IRepository<IUIGameItem>.GetAsync (params object[] keys)
        {
            var httpClient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var boardId = keys[1] as int?;
            var itemId = keys[2] as int?;
            var uriString = string.Format(_itemUrlString, gameName, boardId, itemId);

            var response = await httpClient.GetAsync(uriString);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var item = JsonConvert.DeserializeObject<Item>(contentBody);

                    return item;
                }
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpResourceNotFoundException()
                {
                    HttpResponse = response
                };
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }

        async Task<IUIGameItem> IRepository<IUIGameItem>.UpdateAsync (IUIGameItem entity, params object[] keys)
        {
            var httpClient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var boardId = keys[1] as int?;
            var itemId = keys[2] as int?;
            var uriString = string.Format(_itemUrlString, gameName, boardId, itemId);

            var stringContent = new StringContent(JsonConvert.SerializeObject(entity),
                                                  Encoding.UTF8,
                                                  "application/json");

            var response = await httpClient.PutAsync(uriString, stringContent);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var updatedItem = JsonConvert.DeserializeObject<Item>(contentBody);

                    return updatedItem;
                }
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpResourceNotFoundException()
                {
                    HttpResponse = response
                };
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }
    }
}
