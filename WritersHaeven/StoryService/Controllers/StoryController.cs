using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
