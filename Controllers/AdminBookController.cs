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
        public IActionResult EditBook(int id)
        {

			var book = _adminBookService.GetBook(id);

			//ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ID", "Name", product.ProductCategoryID);
			return View(book);
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            Console.WriteLine(book.Name);
           	if (ModelState.IsValid)
			{
				_adminBookService.updateBook(book);
				return RedirectToAction("Index");
			}
			ViewBag.Id = new SelectList("2", "ID", "Name", book.Id);
			return View(book);
        }
        public IActionResult AddBook()
        {
            return View();
        }

		[HttpPost]
		public ActionResult AddBook(BookListViewModel book)
		{
			if (ModelState.IsValid)
			{
				_adminBookService.CreateBook(book);
				return RedirectToAction("Index");
			}
            Console.WriteLine("CreateNotValid");
            ViewBag.book.id = new SelectList("2", "ID", "Name", book.Id);
			return View(book);
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
