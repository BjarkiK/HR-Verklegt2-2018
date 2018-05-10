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
        public IActionResult index() {
            var bookList = _bookService.getAllBooks();
            return View(bookList);
        }
        public IActionResult allBooks() {
            var allbooks = _bookService.getBookList();
            return View(allbooks);
        }

        public IActionResult details(int id) {
            var book = _bookService.getDetailedBook(id);
            if(book == null) {
                return RedirectToAction("BookNotFound");
            }              
            return View(book);
        }
        public IActionResult horror() {
            var genreBooks = _bookService.getBooksByGenre("Horror");
            return View(genreBooks);
        }
        public IActionResult fantasy() {
            var genreBooks = _bookService.getBooksByGenre("Fantasy");
            return View(genreBooks);
        }
        public IActionResult romance()  {
            var genreBooks = _bookService.getBooksByGenre("Romance");
            return View(genreBooks);
        }
        public IActionResult classic()  {
            var genreBooks = _bookService.getBooksByGenre("Classic");
            return View(genreBooks);
        }
        public IActionResult scifi() {
            var genreBooks = _bookService.getBooksByGenre("Scifi");
            return View(genreBooks);
        }
        public IActionResult crime() {
            var genreBooks = _bookService.getBooksByGenre("Crime");
            return View(genreBooks);
        }
        public IActionResult plays() {
            var genreBooks = _bookService.getBooksByGenre("Plays");
            return View(genreBooks);
        }

        public IActionResult bookNotFound() {
            return View();
        }
        public IActionResult reviewBook() {
            // _bookService.addBookReview(?review?);
            return View();
        }
        public IActionResult bookReviewListDisplay(string bid) {
            /*bookReviewList = _bookService.getBookReviews(bid);
            return View(bookReviewList);*/
            return View();
        }
        public IActionResult booksWithSameAuthor(int id) {
            var authorBookList = _bookService.getBooksByAuthor(id);
            return View(authorBookList);
        }
        public IActionResult booksWithSameGenre(int gid) {
            /*genreBookList = _bookService.getBookByGenre(gid);
            return View(genreBookList);*/
            return View();
        }
        [HttpPost]
        public double totalGradeUpdate(int bid, int grade) {
            var newGrade = _bookService.updateTotalGrade(bid, grade);
            return newGrade;
        }
        public IActionResult search(string searchText) {
            if(searchText != null) {
                var search = _bookService.getBooksWithSearch(searchText);
                if(search != null) 
                {
                    return View(search);
                }
                return View("noResults");
            }
            return View("NotFound");
        }
        public IActionResult advancedSearch(string title, string publisher, string author, string isbn) 
        {
            var search = _bookService.getBooksWithAdvSearch(title, publisher, author, isbn);
            return View();
        }
    }
}
