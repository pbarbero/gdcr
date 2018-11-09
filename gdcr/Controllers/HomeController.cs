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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GameOfLife()
        {
            ViewData["Message"] = "Your application description page.";

            var result = PlayGame();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Dictionary<int, List<Cell>> PlayGame()
        {
            var result = new Dictionary<int, List<Cell>>();
            var grid = new Grid(100, 100);
            grid.SetCenterSeed(10, 100, 100);

            for (int i = 0; i < 2; i++)
            {
                grid.NextIteration();
                result.Add(i, grid.Cells);
            }

            return result;
        }
    }
}
