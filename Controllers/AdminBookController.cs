/*
        Only Admin role can use admin contoller
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;


namespace TheBookCave.Controllers {
    [Authorize(Roles = "ADMIN")]
    public class AdminBookController : Controller {
        private AdminBookService _adminBookService;
        private AuthorService _authorService;
        private GenreService _gernreService;
        private PublisherService _publisherService;
        private BookService _bookService;

        public AdminBookController() {
            _adminBookService = new AdminBookService();
            _authorService = new AuthorService();
            _gernreService = new GenreService();
            _publisherService = new PublisherService();
            _bookService = new BookService();
        
        }
        public IActionResult index() {
            var bookList = _adminBookService.getAllBooks();
            return View(bookList);
        }

        [HttpPost]
        public IActionResult index(string searchString)
        {
            var searchResult = _adminBookService.getSearchResult(searchString);
            if (searchResult == null) {
                return View("NotFound");
            }
            return View(searchResult);
        }

        public IActionResult bookListDisplay() {
            var bookList = _adminBookService.getAllBooks();
            return View(bookList);
        }
        public IActionResult bookDetails(int id) {
            var book = _adminBookService.getBook(id);
            return View(book);
        }
      
        public IActionResult editBook(int id) {
			var book = _bookService.getDetailedBook(id);
            if(!book.Any()) {
                return RedirectToAction("BookNotFound");
            }
			return View(book.First());

        }

        [HttpPost]
        public ActionResult editBook(BookDetailedListViewModel book) {
           	if (ModelState.IsValid) {
				_adminBookService.updateDetaildBook(book);
				return RedirectToAction("index");
			}
			return View(book);
        }



       
        
        public IActionResult removeBook(int id)
        {
            var book = _adminBookService.getBook(id);
            if(!book.Any()) {
                return RedirectToAction("BookNotFound");
            }
			return View(book.First());

        }

        [HttpPost]
        public ActionResult removeBook(BookListViewModel book) {
           	if (ModelState.IsValid) {
				_adminBookService.removeBook(book);
				return RedirectToAction("index");
			}
			return View(book);
        }
        

        public IActionResult bookNotFound() {
           return View();
        }
        public IActionResult addBook() {
           return View();
        }

		[HttpPost]
		public ActionResult addBook(BookListViewModel book) {
			if (ModelState.IsValid) {
				_adminBookService.createBook(book);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
            ViewBag.book.id = new SelectList("2", "ID", "Name", book.Id);
			return View(book);
		}
        public void addAuthor() {
            //_adminBookService.addAuthor();
        }
        public void addPublisher() {
            //_adminBookService.addPublisher();
        }
        public void addGenre() {
            //_adminBookService.addGenre();
        }
    }
}
