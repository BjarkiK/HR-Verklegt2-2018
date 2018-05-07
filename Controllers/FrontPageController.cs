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
    public class FrontPageController : Controller
    {
        private BookService _bookService;

        public FrontPageController() {
            _bookService = new BookService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult top10BooksDisplay()
        {
            var topBooks = _bookService.getTop10Books();
            return View(topBooks);
        }
        public IActionResult newestBooksDisplay()
        {
            var newestBooks = _bookService.getNewestBooks(10);
            return View(newestBooks);
        }
    }
}
