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
        public IActionResult Index()
        {
            var bookList = _bookService.getAllBooks();
            return View(bookList);
           //return View();
        }

        public IActionResult details(int id)
        {
            var detailedBooks = getDetailedBook();
            var book = (from b in detailedBooks
                        where b.Id == id
                        select b).ToList();
            if(detailedBooks.Count == 0) {
                return RedirectToAction("BookNotFound");
            }              
            return View(book);
            
        }

        private List<BookDetailedListViewModel> getDetailedBook() {
            var books = _bookService.getAllBooks();
            var authors = _authorService.getAllAuthors();
            var publishers = _publisherService.getAllPublishers();
            var genres = _genreService.getAllGenres();

            var dBooks =    (from b in books
                            join a in authors
                            on b.AuthorId equals a.AuthorId
                            join p in publishers
                            on b.PublisherId equals p.Id
                            join g in genres
                            on b.GenreId equals g.Id
                            select new BookDetailedListViewModel { 
                                Id = b.Id,
                                Name = b.Name,
                                Price = b.Price,
                                Picture = b.Picture,
                                Grade = b.Grade,
                                DetailsEN = b.DetailsEN,
                                DetailsIS = b.DetailsIS,
                                Discount = b.Discount,
                                Pages = b.Pages,
                                Quantity = b.Quantity,
                                Published = b.Published,
                                Genre = g.GenreEN,
                                Author = a.Name,
                                Publisher = p.Name
                             }).ToList();
            return dBooks;
        }

        public IActionResult BookNotFound() {
            return View();
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
