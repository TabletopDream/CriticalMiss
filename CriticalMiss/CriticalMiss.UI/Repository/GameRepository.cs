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
using System.Net;
using CriticalMiss.UI.Exceptions;
using CriticalMiss.UI.Models.Interfaces;

namespace CriticalMiss.UI.Repository
{
    public class GameRepository : IGameRepository
    {
        private ILibraryHttpClientProvider _libProvider;

        public GameRepository(ILibraryHttpClientProvider libProvider)
        {
            _libProvider = libProvider;
        }

        async Task<IUIGame> IRepository<IUIGame>.AddAsync (IUIGame entity, params object[] keys)
        {
            var httpclient = _libProvider.LibraryConnection;

            var stringContent = new StringContent(JsonConvert.SerializeObject(entity),
                                                  Encoding.UTF8,
                                                  "application/json");
            var response = await httpclient.PostAsync("api/games", stringContent);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var game = JsonConvert.DeserializeObject<Game>(contentBody);

                    return game;
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

        async Task IRepository<IUIGame>.DeleteAsync (IUIGame entity, params object[] keys)
        {
            if (keys.Length != 1)
            {
                throw new ArgumentException("Delete keys not correct length.");
            }

            var httpclient = _libProvider.LibraryConnection;
            var gameName = keys[0] as string;
            var response = await httpclient.DeleteAsync("api/games/" + gameName);

            if (response.IsSuccessStatusCode)
            {
                return;
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

        Task IRepository<IUIGame>.DeleteAsync (params object[] keys)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<IUIGame>> IRepository<IUIGame>.GetAllAsync (params object[] keys)
        {
            var httpClient = _libProvider.LibraryConnection;

            var response = await httpClient.GetAsync("api/games");

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();
                    var gameList = JsonConvert.DeserializeObject<List<Game>>(contentBody);

                    return gameList;
                }
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }

        async Task<IUIGame> IRepository<IUIGame>.GetAsync (params object[] keys)
        {
            if (keys.Length != 1)
            {
                throw new ArgumentException("Passed param keys invalid!");
            }

            var gameName = keys[0] as string;
            var httpClient = _libProvider.LibraryConnection;
            var response = await httpClient.GetAsync("api/games/" + gameName);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentbody = await content.ReadAsStringAsync();
                    var board = JsonConvert.DeserializeObject<Game>(contentbody);
                    string contentBody = await content.ReadAsStringAsync();
                    var game = JsonConvert.DeserializeObject<Game>(contentBody);

                    return game;
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

        async Task<IUIGame> IRepository<IUIGame>.UpdateAsync (IUIGame entity, params object[] keys)
        {
            var httpclient = _libProvider.LibraryConnection;

            var gameName = keys[0] as string;
            var stringContent = new StringContent(JsonConvert.SerializeObject(entity),
                                                  Encoding.UTF8,
                                                  "application/json");
            var response = await httpclient.PutAsync("api/games/" + gameName, stringContent);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var game = JsonConvert.DeserializeObject<Game>(contentBody);

                    return game;
                }
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
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
