using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CriticalMiss.Library.Models;
using CriticalMiss.WebService.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.WebService.Library.Controllers
{
    [Produces("application/json")]
    [Route("api/Games/{gameName}/Boards")]
    public class BoardController : Controller
    {
        // GET: api/Board
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] string gameName)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/boards?gameName=" + gameName); //Allows returning of all boards from certain game: gameName
            if (response.IsSuccessStatusCode)
            {
                var boards = JsonConvert.DeserializeObject<List<Game>>(await response.Content.ReadAsStringAsync());
                return Ok(boards);
            }

            return BadRequest();
        }

        // GET: api/Board/5
        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetAsync([FromRoute]string gameName, [FromRoute]int boardId)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/boards?gameName=" + gameName + "&boardId=" + boardId);
            if (response.IsSuccessStatusCode)
            {
                var board = JsonConvert.DeserializeObject<List<Board>>(await response.Content.ReadAsStringAsync());
                if(board.Count == 0)
                {
                    return NotFound();
                }
                else if(board.Count > 1)
                {
                    throw new InvalidOperationException();
                }
                return Ok(board);
            }

            return BadRequest();
        }
        
        // POST: api/Board
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Board board)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var content = JsonConvert.SerializeObject(board);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.Client.PostAsync("api/boards/", stringContent);

            if(response.IsSuccessStatusCode)
            {
                return Ok(board);
            }
            return BadRequest();
        }
        
        // PUT: api/Board/5
        [HttpPut("{boardId}")]
        public async Task<IActionResult> PutAsync([FromRoute]int boardId, [FromBody]Board board)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var content = JsonConvert.SerializeObject(board);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.Client.PutAsync("api/boards/" + boardId.ToString(), stringContent);

            if (response.IsSuccessStatusCode)
            {
                return Ok(board);
            }
            return BadRequest();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            HttpBaseInformation c = new HttpBaseInformation();

            var response = await c.Client.DeleteAsync("api/boards/" + id.ToString());
            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
