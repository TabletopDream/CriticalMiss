using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers
{
    [Produces("application/json")]
    [Route("api/games/{gameName/boards/{boardId:int}/items")]
    public class BoardItemController : Controller
    {
    }
}