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
    [Route("api/Game/{gameName}/Board")]
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

            var response = await client.Client.GetAsync("api/games/{name}/boards/{boardId}");
            if (response.IsSuccessStatusCode)
            {
                var board = JsonConvert.DeserializeObject<Board>(await response.Content.ReadAsStringAsync());
                return Ok(board);
            }

            return BadRequest();
        }
        
        // POST: api/Board
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Board/5
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
