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

        public List<BookListViewModel> getAllBooks() {
            var books = _bookRepo.getAllBooks();

            return books;
        }

        public List<BookListViewModel> getBook(int bid) {
            var book = _bookRepo.getBook(bid);
            return book;
        }
        public List<UserReviewListViewModel> getBookReviews(int bid) { 
            var reviews = _userGradeRepo.getAllReviewsBook(bid);
            
            return reviews;
        }
        public void addBookReview() {
            //var review = _userGradeRepo.CreateReview(userReview)
        }
        public void updateTotalGrade(int bid) {
            //TODO
        }
        
        public List<BookListViewModel> getTop10Books() {
            var books = _bookRepo.getAllBooks();
            return books;
        }
        public List<BookListViewModel> getNewestBooks(int n) {
            /*var books = _bookRepo.GetAllBooks();
            Taka svo n fjölda nýjustu úr öllum??
            return books;*/
            return null;
        }
        public List<BookListViewModel> getBooksByGenre(string genre) {
            /* Sækja öll genre og finna rétta til að fá ID
            var genres = _genreRepo.GetAllGenre();
            int genreId = genre.id
            Senda id inní book repo til að finna allar bækur inní því genre
             var books = _bookRepo.GetAllBooks();
            where genreId == books.genreId*/
            return null;
        }
        public List<BookListViewModel> getBooksByAuthor(string author) {
            /* Sækja alla authors og finna rétta til að fá ID
            var authors = _authorRepo.GetAllAuthor();
            int authorId = author.id
            Senda id inní book repo til að finna allar bækur frá þeim author
             var books = _bookRepo.GetAllBooks();
            where authorId == books.authorId*/
            return null;
        }
        public List<BookListViewModel> getBooksWithSearch(string param) {
            /* Tekur param og ber saman við heiti eða author, hugsanlega genre? */
            return null;
        }
        public List<BookListViewModel> getBooksWithAdvSearch(string param1, string param2, string param3, string param4, string param5) {
            /* tekur marga param og leitar út frá því */
            return null;
        }
    }
}
