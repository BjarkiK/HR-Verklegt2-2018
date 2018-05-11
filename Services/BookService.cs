using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System.Linq;
using TheBookCave.Data.EntityModels;

namespace TheBookCave.Services {
    public class BookService {
        private BookRepo _bookRepo;
        private UserGradeRepo _userGradeRepo;
        private GenreRepo _genreRepo;
        private AuthorRepo _authorRepo;
        private PublisherRepo _publisherRepo;

        public BookService() {
            _bookRepo = new BookRepo();
            _userGradeRepo = new UserGradeRepo();
            _genreRepo = new GenreRepo();
            _authorRepo = new AuthorRepo();
            _publisherRepo = new PublisherRepo();
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
        public double updateTotalGrade(int bid, int grade) {
            var book = _bookRepo.getBookData(bid);
            book.Grade += grade;
            book.NrOfGrades += 1;
            _bookRepo.updateBook(book);

            var newGrade = (book.Grade / book.NrOfGrades);
            return newGrade;
        }
        

        public List<BookDetailedListViewModel> getBookList() {
            var books = _bookRepo.getAllBooks();
            var authors = _authorRepo.getAllAuthors();
            var publishers = _publisherRepo.getAllPublishers();
            var genres = _genreRepo.getAllGenres();
            var joined =    (from b in books
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
                                NrOfGrades = b.NrOfGrades,
                                Grade = b.Grade,
                                DetailsEN = b.DetailsEN,
                                DetailsIS = b.DetailsIS,
                                Discount = b.Discount,
                                Pages = b.Pages,
                                Quantity = b.Quantity,
                                Published = b.Published,
                                Genre = g.GenreEN,
                                Author = a.Name,
                                Publisher = p.Name,
                                Authors = authors,
                                Publishers = publishers,
                                Genres = genres
                             }).ToList();
             var alphabeticalOrder = ( from b in joined orderby b.Name ascending
				select b).ToList();
            
            return alphabeticalOrder;
        }
        public List<BookDetailedListViewModel> getDetailedBook(int id) {
            var books = getBookList();
            List<BookDetailedListViewModel> detailedBook = books.Where(b => b.Id == id).ToList();
            if (detailedBook.Count == 0) {
                return null;
            }
            return detailedBook;
        }
        
        public List<BookDetailedListViewModel> getTop10Books() {
            var books = getBookList();
            List<BookDetailedListViewModel> topBooks = books.OrderByDescending(s => (s.Grade / s.NrOfGrades)).Select(x => x).Take(10).ToList();
            return topBooks;
        }

        public List<BookDetailedListViewModel> getNewestBooks(int n) {
            var books = getBookList();
            List<BookDetailedListViewModel> newestBooks = books.OrderByDescending(x => x.Id).Select(x => x).Take(n).ToList();
            return newestBooks;
        }

        public List<BookDetailedListViewModel> getBooksByGenre(string genre) {
            var books = getBookList();
            List<BookDetailedListViewModel> genreBooks = books.Where(g => g.Genre == genre).ToList();
            var alphabeticalOrder = ( from b in genreBooks orderby b.Name ascending
				select b).ToList();
            if (genreBooks.Count == 0){
                return null;
            }
            return alphabeticalOrder;
        }
        public List<BookDetailedListViewModel> getBooksByAuthor(string author) {
            var books = getBookList();
            List<BookDetailedListViewModel> authorsBooks = books.Where(a => a.Author == author).ToList();
            if (authorsBooks.Count == 0){
                return null;
            }
            return authorsBooks;
        }
        public List<BookListViewModel> getBooksByAuthor(int aid) {
            var books = _bookRepo.getAllBooks();
            List<BookListViewModel> authorsBooks = books.Where(b => b.AuthorId == aid).ToList();
            if (authorsBooks.Count == 0){
                return null;
            }
            return authorsBooks;
        }
        public List<BookDetailedListViewModel> getBooksWithSearch(string param) {
            var books = getBookList();
            List<BookDetailedListViewModel> searchResult = books.Where(b => b.Author.ToLower().Contains(param.ToLower())
                                                                         || b.Name.ToLower().Contains(param.ToLower())
                                                                         || b.Genre.ToLower().Contains(param.ToLower())).ToList();
            return searchResult;
        }
        public List<BookDetailedListViewModel> getBooksWithAdvSearch(string param1, string param2, string param3, string param4) {
            /* tekur marga param og leitar út frá því */
            var books = getBookList();
            if(param1 != null && param2 == null && param3 == null && param4 == null)
            {
                List<BookDetailedListViewModel> searchResult = books.Where(b => b.Name.ToLower().Contains(param1.ToLower())).ToList();
                return searchResult;
            }
            return null;
        }
    }
}
