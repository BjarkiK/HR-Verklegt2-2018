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
    public class BookController : Controller
    {
        private BookService _bookService;

        public BookController() {
            _bookService = new BookService();
        }
        public IActionResult Index()
        {
            var bookList = _bookService.getAllBooks();
            return View(bookList);
           //return View();
        }

        public IActionResult details(int id)
        {
            var book = _bookService.getBook(id);
            return View(book);
            
        }

       
        public IActionResult reviewBook()
        {
            // _bookService.addBookReview(?review?);
            return View();
        }
       
        public IActionResult totalGradeUpdate(string bid)
        {
            //_bookService.updateTotalGrade(bid);
            return View();
        }
        public IActionResult bookReviewListDisplay(string bid)
        {
            /*bookReviewList = _bookService.getBookReviews(bid);
            return View(bookReviewList);*/
            return View();
        }
        public IActionResult booksWithSameAuthor(int aid)
        {
            /*authorBookList = _bookService.getBookByAuthor(aid);
            return View(authorBookList);*/
            return View();
        }
        public IActionResult booksWithSameGenre(int gid)
        {
            /*genreBookList = _bookService.getBookByGenre(gid);
            return View(genreBookList);*/
            return View();
        }
    }
}
