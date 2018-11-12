using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gdcr.Models;
using GameOfLife.Library;

namespace gdcr.Controllers
{
    public class HomeController : Controller
    {
        private Grid Grid { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GameOfLife()
        {
            ViewData["Message"] = "Your application description page.";

            var grid = PlayGame();

            return View(grid);
        }

        [HttpPost]
        public JsonResult NextIteration()
        {
            Grid.NextIteration();

            return Json(Grid);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Grid PlayGame()
        {
            var result = new Dictionary<int, List<Cell>>();
            var grid = new Grid(10, 20);
            grid.SetCenterSeed(20);

            return grid;
        }
    }
}
