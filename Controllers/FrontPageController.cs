using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class FrontPageController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;

        public FrontPageController() {
            _bookService = new BookService();
            _authorService = new AuthorService();
        }
        public IActionResult Index() {
            var topBooks = _bookService.getTop10Books();    
            return View(topBooks);
        }
        public IActionResult top10BooksDisplay()  {
            var topBooks = _bookService.getTop10Books();
            return View(topBooks);
        }
        public IActionResult newestBooksDisplay() {
            var newestBooks = _bookService.getNewestBooks(10);
            return View(newestBooks);
        }
    }
}
