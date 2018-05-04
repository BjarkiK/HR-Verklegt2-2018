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
    public class AdminBookController : Controller
    {
        //private AdminBookService _adminBookService;


        public AdminBookController() {
            //_adminSubscriptionService = new AdminSubscriptionService();
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
        public void addBook()
        {
            //_adminBookService.addBook();
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
