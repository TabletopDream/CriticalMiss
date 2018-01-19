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
    [Route("api/Games/{gameName}/Boards/{BoardId}/BoardItems")]
    public class BoardItemController : Controller
    {
        private HttpBaseInformation _client;

        public BoardItemController()
        {
            _client = new HttpBaseInformation();
        }

        // GET: api/BoardItem
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BoardItem/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _client.Client.GetAsync("api/items/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var game = JsonConvert.DeserializeObject<BoardItem>(await response.Content.ReadAsStringAsync());
                return Ok(game);
            }

            return BadRequest();
        }

        // POST: api/BoardItem
        [HttpPost("{id}")]
        public async Task PostAsync([FromRoute]int id)
        {
            BoardItem item = new BoardItem(id);

            var content = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.Client.PostAsync("api/items/", stringContent);
        }
        
        // PUT: api/BoardItem/5
        [HttpPut("{id}")]
        public async Task PutAsync([FromRoute]int id, [FromBody]BoardItem item)
        {
            var content = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.Client.PutAsync("api/items/" + id.ToString(), stringContent);
            if (response.IsSuccessStatusCode)
            {
                return;
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var response = await _client.Client.DeleteAsync("api/items/" + id.ToString());
            return response.StatusCode;
        }
    }
}
