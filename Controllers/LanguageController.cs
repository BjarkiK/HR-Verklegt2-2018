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
    public class LanguageController : Controller
    {
        //private PageService _pageService;

        public LanguageController() {
            //_pageService = new PageService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public void changeLanguage()
        {
            //_pageService.changeLanguage();
        }
    }
}
