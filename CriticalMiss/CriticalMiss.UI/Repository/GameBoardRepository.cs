using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Exceptions;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CriticalMiss.UI.Repository
{
    public class GameBoardRepository : IGameBoardRepository
    {
        private ILibraryHttpClientProvider _libProvider;

        public GameBoardRepository(ILibraryHttpClientProvider libProvider)
        {
            _libProvider = libProvider;
        }

        async Task<IBoard> IGameBoardRepository.AddAsync (string gameName, IBoard entity)
        { 
            var httpClient = _libProvider.LibraryConnection;

            var uriString = string.Format("/api/games/{0}/boards", gameName);
            var requestContent = new StringContent(JsonConvert.SerializeObject(entity),
                                                   Encoding.UTF8,
                                                   "application/json");
            var response = await httpClient.PostAsync(uriString, requestContent);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();
                    var createdBoard = JsonConvert.DeserializeObject<Board>(contentBody);

                    return createdBoard;
                }
            }

            throw new HttpServiceException()
            {
                HttpResponse = response
            };
        }

        async Task<bool> IGameBoardRepository.BoardExistsAsync (string gameName, int boardId)
        {
            var httpClient = _libProvider.LibraryConnection;

            var uriString = string.Format("/api/games/{0}/boards/{1}", gameName, boardId);

            var response = await httpClient.GetAsync(uriString);

            return response.IsSuccessStatusCode;
        }

        async Task IGameBoardRepository.DeleteAsync (string gameName, int boardId)
        {
            var httpClient = _libProvider.LibraryConnection;

            var uriString = string.Format("/api/games/{0}/boards/{1}", gameName, boardId);

            var response = await httpClient.DeleteAsync(uriString);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new HttpResourceNotFoundException()
                    {
                        HttpResponse = response
                    };
                }
                else
                {
                    throw new HttpServiceException()
                    {
                        HttpResponse = response
                    };
                }
            }
            return;
        }

        async Task<IEnumerable<IBoard>> IGameBoardRepository.GetBoardsForGameAsync (string gameName)
        {
            var httpClient = _libProvider.LibraryConnection;

            var uriString = string.Format("/api/games/{0}/boards", gameName);
            var response = await httpClient.GetAsync(uriString);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();
                    var boardList = JsonConvert.DeserializeObject<List<Board>>(contentBody);

                    return boardList;
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

        async Task<IBoard> IGameBoardRepository.GetByRelativeIdAsync (string gameName, int boardId)
        {
            var httpClient = _libProvider.LibraryConnection;

            var uriString = string.Format("/api/games/{0}/boards/{1}", gameName, boardId);
            var response = await httpClient.GetAsync(uriString);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();
                    var board = JsonConvert.DeserializeObject<Board>(contentBody);

                    return board;
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

        async Task<IBoard> IGameBoardRepository.UpdateAsync (string gameName, int boardId, IBoard entity)
        {
            var httpClient = _libProvider.LibraryConnection;
            var uriString = string.Format("/api/games/{0}/boards/{1}", gameName, boardId);
            var stringContent = new StringContent(JsonConvert.SerializeObject(entity),
                                                  Encoding.UTF8,
                                                  "application/json");

            var response = await httpClient.PutAsync(uriString, stringContent);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    var contentBody = await content.ReadAsStringAsync();

                    var updatedBoard = JsonConvert.DeserializeObject<Board>(contentBody);


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
