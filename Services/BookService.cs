using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class BookService {
        private BookRepo _bookRepo;
        private UserGradeRepo _userGradeRepo;
        private GenreRepo _genreRepo;
        private AuthorRepo _authorRepo;

        public BookService() {
            _bookRepo = new BookRepo();
            _userGradeRepo = new UserGradeRepo();
            _genreRepo = new GenreRepo();
            _authorRepo = new AuthorRepo();
        }

        public List<BookListViewModel> GetAllBooks() {
            var books = _bookRepo.GetAllBooks();

            return books;
        }

        public List<BookListViewModel> GetBook(int bid) {
            var book = _bookRepo.GetBook(bid);

            return book;
        }
        public List<UserReviewListViewModel> GetBookReviews(int bid) { 
            var reviews = _userGradeRepo.GetAllReviewsBook(bid);
            
            return reviews;
        }
        public void AddBookReview() {
            //var review = _userGradeRepo.CreateReview(userReview)
        }
        public void UpdateTotalGrade(int bid) {
            //TODO
        }
        public void AddBookToCartCookie(int bid) {
            // AJAX?
        }
        public List<BookListViewModel> GetTop10Books() {
            /*var books = _bookRepo.GetAllBooks();
            Taka svo top 10 úr öllum??
            return books;*/
            return null;
        }
        public List<BookListViewModel> GetNewestBooks(int n) {
            /*var books = _bookRepo.GetAllBooks();
            Taka svo n fjölda nýjustu úr öllum??
            return books;*/
            return null;
        }
        public List<BookListViewModel> GetBooksByGenre(string genre) {
            /* Sækja öll genre og finna rétta til að fá ID
            var genres = _genreRepo.GetAllGenre();
            int genreId = genre.id
            Senda id inní book repo til að finna allar bækur inní því genre
             var books = _bookRepo.GetAllBooks();
            where genreId == books.genreId*/
            return null;
        }
        public List<BookListViewModel> GetBooksByAuthor(string author) {
            /* Sækja alla authors og finna rétta til að fá ID
            var authors = _authorRepo.GetAllAuthor();
            int authorId = author.id
            Senda id inní book repo til að finna allar bækur frá þeim author
             var books = _bookRepo.GetAllBooks();
            where authorId == books.authorId*/
            return null;
        }
        public List<BookListViewModel> GetBooksWithSearch(string param) {
            /* Tekur param og ber saman við heiti eða author, hugsanlega genre? */
            return null;
        }
        public List<BookListViewModel> GetBooksWithAdvSearch(string param1, string param2, string param3, string param4, string param5) {
            /* tekur marga param og leitar út frá því */
            return null;
        }
    }
}
