using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Library.Models;
using CriticalMiss.WebService.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.WebService.Library.Controllers
{
    [Produces("application/json")]
    [Route("api/BoardItem")]
    public class BoardItemController : Controller
    {
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
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/games/{gameName}/boards/{boardId}/items/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var game = JsonConvert.DeserializeObject<BoardItem>(await response.Content.ReadAsStringAsync());
                return Ok(game);
            }

            return BadRequest();
        }
        
        // POST: api/BoardItem
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/BoardItem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
