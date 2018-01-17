using CriticalMiss.Common.Interfaces;
using CriticalMiss.UI.Models;
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

        Task<IBoard> IGameBoardRepository.AddBoardRelativeAsync (string gameName, IBoard gameBoard)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGameBoardRepository.BoardExistsAsync (string gameName, int boardId)
        {
            throw new NotImplementedException();
        }

        async Task<IBoard> IRepository<IBoard>.DeleteAsync (IBoard entity)
        {
            throw new NotImplementedException();
        }

        Task IGameBoardRepository.DeleteRelativeAsync (string gameName, int boardId)
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
                    var boardList = JsonConvert.DeserializeObject<List<Board>>(contentBody);

                    return boardList;
                }
            }

            return null;
        }

        async Task<IEnumerable<IBoard>> IGameBoardRepository.GetAllForBoardAsync (string gameName)
        {
            var httpClient = _dbProvider.DatabaseConnection;

            var response = await httpClient.GetAsync("/api/boards?game=" + gameName);

            if (response.Content != null)
            {
                using (HttpContent content = response.Content)
                {
                    string contentBody = await content.ReadAsStringAsync();
                    var boardList = JsonConvert.DeserializeObject<List<Board>>(contentBody);

                    return boardList;
                }
            }
            throw new NotImplementedException();
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

        async Task<IBoard> IGameBoardRepository.GetByRelativeIdAsync (string gameName, int boardId)
        {
            throw new NotImplementedException();
        }

        async Task<IBoard> IRepository<IBoard>.UpdateAsync (IBoard entity)
        {
            throw new NotImplementedException();
        }

        async Task<IBoard> IGameBoardRepository.UpdateBoardAsync (string gameName, int boardId, IBoard gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
