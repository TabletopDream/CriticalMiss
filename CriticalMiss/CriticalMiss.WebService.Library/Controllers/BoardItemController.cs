﻿using System;
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
    [Route("api/Games/{gameName}/Boards/{BoardId}/Items")]
    public class BoardItemController : Controller
    {
        private HttpBaseInformation _client;

        public BoardItemController()
        {
            _client = new HttpBaseInformation();
        }

        // GET: api/BoardItem
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromRoute]string gameName, [FromRoute]int boardId)
        {
            var response = await _client.Client.GetAsync("api/items?gameName=" + gameName + "&boardId=" + boardId); 
            if (response.IsSuccessStatusCode)
            {
                var items = JsonConvert.DeserializeObject<List<BoardItem>>(await response.Content.ReadAsStringAsync());
                return Ok(items);
            }
            else if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            return BadRequest();
        }

        // GET: api/BoardItem/5
        //[HttpGet("{id}", Name = "GetItem")]
        //public async Task<IActionResult> GetAsync(int id)
        //{
        //    var response = await _client.Client.GetAsync("api/items/" + id.ToString());
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var game = JsonConvert.DeserializeObject<BoardItem>(await response.Content.ReadAsStringAsync());
        //        return Ok(game);
        //    }

        //    return BadRequest();
        //}

        // POST: api/BoardItem
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromRoute]string gameName, [FromRoute]int boardId, [FromBody]BoardItem item) //Make sure you use pluck before serializing
        {
            item.ImageAssetId = item.ImageAsset.ImageAssetId;
            item.ImageAsset = null;
            var stringContent = new StringContent(JsonConvert.SerializeObject(item),
                                                  Encoding.UTF8,
                                                  "application/json");
            var connString = string.Format("api/items?gameName={0}&boardId={1}", gameName, boardId);
            var response = await _client.Client.PostAsync(connString, stringContent);

            if (response.IsSuccessStatusCode)
            {
                var newItem = JsonConvert.DeserializeObject<BoardItem>(await response.Content.ReadAsStringAsync());

                return Ok(newItem);
            }

            return BadRequest(response.ReasonPhrase);
        }
        
        // PUT: api/BoardItem/5
        [HttpPut("{itemId}")]
        public async Task<IActionResult> PutAsync([FromRoute]int itemId, [FromRoute]int boardId, [FromRoute]string gameName, [FromBody]BoardItem item) //make sure it uses pluck before serializing
        {
            item.PluckImageId();
            item.ImageAsset = null;
            var content = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.Client.PutAsync("api/items/" + itemId.ToString() + "?gameName=" + gameName + "&boardId=" + boardId, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var updatedItem = JsonConvert.DeserializeObject<BoardItem>(await response.Content.ReadAsStringAsync());

                return Ok(updatedItem);
            }
            return BadRequest();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int itemId, [FromRoute]int boardId, [FromRoute]string gameName)
        {
            var response = await _client.Client.DeleteAsync("api/items?itemId=" + itemId.ToString() + "&boardId=" + boardId.ToString() + "&gameName=" + gameName);
            if(response.IsSuccessStatusCode)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
