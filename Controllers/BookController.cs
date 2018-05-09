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
    public class BookController : Controller
    {
        private BookService _bookService;
        private AuthorService _authorService;
        private GenreService _genreService;
        private PublisherService _publisherService;

        public BookController() {
            _bookService = new BookService();
            _authorService = new AuthorService();
            _genreService = new GenreService();
            _publisherService = new PublisherService();
        }
        public IActionResult index()
        {
            var bookList = _bookService.getAllBooks();
            return View(bookList);
        }
        public IActionResult allBooks()
        {
            var allbooks = _bookService.getAllBooks();
            return View(allbooks);
        }

        public IActionResult details(int id)
        {
            var book = _bookService.getDetailedBook(id);
            if(book == null) {
                return RedirectToAction("BookNotFound");
            }              
            return View(book);
        }

        public IActionResult bookNotFound() {
            return View();
        }
        public IActionResult reviewBook()
        {
            // _bookService.addBookReview(?review?);
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
        [HttpPost]
        public void totalGradeUpdate(int bid, int grade)
        {
            _bookService.updateTotalGrade(bid, grade);
        }
    }
}
