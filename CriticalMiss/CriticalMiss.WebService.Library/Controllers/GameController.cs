using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CriticalMiss.Common.Interfaces;
using CriticalMiss.Library.Models;
using CriticalMiss.WebService.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.WebService.Library.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GameController : Controller
    {
        // GET: api/Game
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/games");
            if (response.IsSuccessStatusCode)
            {
                var game = JsonConvert.DeserializeObject<List<Game>>(await response.Content.ReadAsStringAsync());
                return Ok(game);
            }

            return BadRequest();
        }

        // GET: api/Game/5
        [HttpGet("{gameName}", Name = "Get")]
        public async Task<IActionResult> Get(string gameName)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/games/" + gameName);
            if (response.IsSuccessStatusCode)
            {
                var game = JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());
                return Ok(game);
            }

            return BadRequest();
        }
        
        // POST: api/Game
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Game game)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var content = JsonConvert.SerializeObject(game);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.Client.PostAsync("api/games/", stringContent);
            if(!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            Board board = new Board(20, 20, 1, game.GameName);
            var con = JsonConvert.SerializeObject(board);
            var stringCon = new StringContent(con, Encoding.UTF8, "application/json");
            var res = await client.Client.PostAsync("api/boards", stringCon);
            if(res.IsSuccessStatusCode)
            {
                return Ok(game);
            }

            return BadRequest();
        }
        
        // PUT: api/Game/5
        [HttpPut("{gameName}")]
        public async Task<IActionResult> PutAsync([FromRoute]string gameName, [FromBody]Game game)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var content = JsonConvert.SerializeObject(game);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.Client.PutAsync("api/games/" + gameName, stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Ok(game);
            }
            return BadRequest();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{gameName}")]
        public async Task<IActionResult> Delete(string gameName)
        {
            HttpBaseInformation c = new HttpBaseInformation();

            var response = await c.Client.DeleteAsync("api/games/" + gameName);
            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
