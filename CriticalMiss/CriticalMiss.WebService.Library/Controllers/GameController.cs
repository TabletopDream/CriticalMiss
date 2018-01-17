﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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
    [Route("api/Game")]
    public class GameController : Controller
    {
        // GET: api/Game
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Game/5
        [HttpGet("{gameName}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            HttpBaseInformation client = new HttpBaseInformation();

            var response = await client.Client.GetAsync("api/games/{name}");
            if (response.IsSuccessStatusCode)
            {
                var game = JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());
                return Ok(game);
            }

            return BadRequest();
        }
        
        // POST: api/Game
        [HttpPost]
        public void Post([FromBody]string name)
        {
            
        }
        
        // PUT: api/Game/5
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
