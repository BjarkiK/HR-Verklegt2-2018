using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class HelpCenterController : Controller
    {
        //private HelpService _hookService;

        public HelpCenterController() {
            //_helpService = new HelpService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult helpSearchDisplay(string search)
        {
            /*var searchResults = _helpService.getHelpBySearch(search);
            return View(searchResults);*/
            return View();
        }
        public IActionResult getHelpByGenre(string genre)
        {
            /*var genreHelp = _helpService.getHelpByGenre(genre);
            return View(genreHelp);*/
            return View();
        }
    }
}
