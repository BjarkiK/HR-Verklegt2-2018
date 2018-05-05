using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models;
using TheBookCave.Models.ViewModels;
using TheBookCave.Services;

namespace TheBookCave.Controllers
{
    public class AdminBookController : Controller
    {
        private AdminBookService _adminBookService;


        public AdminBookController() {
            _adminBookService = new AdminBookService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult bookListDisplay()
        {
            /*var bookList = _adminBookService.getAllBooks();
            return View(bookList);*/
            return View();
        }
        public IActionResult bookDetails(string bid)
        {
            /*var book = _adminBookService.getBook(bid);
            return View(book);*/
            return View();
        }
        public void bookUpdate(string bid)
        {
            //_adminBookService.updateBook(bid);
        }
        public IActionResult CreateBook()
        {
            Console.WriteLine("AddBook");
            return View();
        }

		[HttpPost]
		public ActionResult CreateBook(Book book)
		{
			if (ModelState.IsValid)
			{
				_adminBookService.CreateBook(book);
                 Console.WriteLine("HURRA");
				return RedirectToAction("Index");
			}
            Console.WriteLine("Hello");
            return RedirectToAction("Index");
		}
        public void addAuthor()
        {
            //_adminBookService.addAuthor();
        }
        public void addPublisher()
        {
            //_adminBookService.addPublisher();
        }
        public void addGenre()
        {
            //_adminBookService.addGenre();
        }
    }
}
