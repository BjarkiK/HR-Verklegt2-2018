using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Services;

namespace SpotifyLite.Controllers
{
    public class HomeController : Controller
    {
        private ArtistService _artistService;

        public HomeController() {
            _artistService = new ArtistService();
        }
        public IActionResult Index()
        {
            var artists = _artistService.GetAllArtists();
            return View(artists);
        }
    }
}
