using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers.API
{
    public class ItemRestConsumeController : Controller
    {

        private IGameItemRepository _itemrepository;
        public ItemRestConsumeController(IGameItemRepository itemrepository)
        {
            _itemrepository = itemrepository;
        }
        //public async Task<ActionResult> GEtAllItem()
        //{
        //    var getitem = await _itemrepository.GetAllAsync();
        //    return View(getitem);
        //}
        //public async Task<ActionResult> GetItemById(int id)
        //{
        //    var getitembyid = await _itemrepository.GetByIdAsync(id);
        //    return View(getitembyid);
        //}
        //public async Task<ActionResult> CreateGame([FromBody] Item item)
        //{
        //    var creatiteme = await _itemrepository.AddAsync(item);

        //    return null;
        //}
    }
}