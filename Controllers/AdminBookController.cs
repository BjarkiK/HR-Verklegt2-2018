using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;


namespace TheBookCave.Controllers {
    public class AdminBookController : Controller {
        private AdminBookService _adminBookService;


        public AdminBookController() {
            _adminBookService = new AdminBookService();
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
            var book = _adminBookService.GetBook(id);
            return View(book);
        }
        public IActionResult EditBook(int id) {
			var book = _adminBookService.GetBook(id);
            if(!book.Any()) {
                return RedirectToAction("BookNotFound");
            }
			return View(book.First());

        }
        [HttpPost]
        public ActionResult EditBook(BookListViewModel book) {
            Console.WriteLine(book.Name);
           	if (ModelState.IsValid) {
				_adminBookService.updateBook(book);
				return RedirectToAction("index");
			}
			return View(book);
        }
        
        public IActionResult RemoveBook(int id)
        {
            var book = _adminBookService.GetBook(id);
            if(!book.Any()) {
                return RedirectToAction("BookNotFound");
            }
			return View(book.First());

        }

        [HttpPost]
        public ActionResult RemoveBook(BookListViewModel book) {
            Console.WriteLine(book.Name);
           	if (ModelState.IsValid) {
				_adminBookService.removeBook(book);
				return RedirectToAction("index");
			}
			return View(book);
        }
        

        public IActionResult BookNotFound() {
           return View();
        }
        public IActionResult AddBook() {
           return View();
        }

		[HttpPost]
		public ActionResult AddBook(BookListViewModel book) {
			if (ModelState.IsValid) {
				_adminBookService.CreateBook(book);
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
