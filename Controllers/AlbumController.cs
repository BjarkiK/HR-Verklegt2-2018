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
    public class AlbumController : Controller
    {
        private AlbumService _albumService;

        public AlbumController() {
            _albumService = new AlbumService();
        }
        public IActionResult Index()
        {
            var albums = _albumService.GetAllAlbums();
            return View(albums);
        }
    }
}
