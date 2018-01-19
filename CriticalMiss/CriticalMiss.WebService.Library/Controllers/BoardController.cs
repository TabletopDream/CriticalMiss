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
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Board/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int boardId)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/boards/{boardId}");
            if (response.IsSuccessStatusCode)
            {
                var board = JsonConvert.DeserializeObject<Board>(await response.Content.ReadAsStringAsync());
                return Ok(board);
            }

            return BadRequest();
        }
        
        // POST: api/Board
        [HttpPost]
        public async Task PostAsync([FromBody]int id)
        {
            HttpBaseInformation client = new HttpBaseInformation();
            Board b = new Board(20,20,id);

            var content = JsonConvert.SerializeObject(b);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.Client.PostAsync("api/boards/" + id.ToString(), stringContent);
        }
        
        // PUT: api/Board/5
        [HttpPut("{id}")]
        public async Task PutAsync([FromRoute]int id, [FromBody]Board board)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var content = JsonConvert.SerializeObject(board);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.Client.PutAsync("api/boards/" + id, stringContent);

            if (response.IsSuccessStatusCode)
            {
                return;
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            HttpBaseInformation c = new HttpBaseInformation();

            var response = await c.Client.DeleteAsync("api/boards/" + id.ToString());
            return response.StatusCode;
        }
    }
}
