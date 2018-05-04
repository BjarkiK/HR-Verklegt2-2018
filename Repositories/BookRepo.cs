using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class BookRepo {
        private DataContext _db;

        public BookRepo() {
            _db = new DataContext();
        }
        public List<BookListViewModel> GetBook(int bid) {
            var book = (from b in _db.Books
                                where b.Id == bid
                                select new BookListViewModel {
                                Id = b.Id,
                                AuthorId = b.AuthorId,
                                DetailsEN = b.DetailsEN,
                                DetailsIS = b.DetailsIS,
                                Discount = b.Discount,
                                GenreId = b.GenreId,
                                Name = b.Name,
                                Picture = b.Picture,
                                PublisherId = b.PublisherId,
                                grade = b.grade,
                                pages = b.pages,
                                price = b.price,
                                published = b.published,
                                quantity = b.quantity 
                                }).ToList();
            return book;
        }
        public List<BookListViewModel> GetAllBooks() {
            var books = (from b in _db.Books
                                select new BookListViewModel {
                                Id = b.Id,
                                AuthorId = b.AuthorId,
                                DetailsEN = b.DetailsEN,
                                DetailsIS = b.DetailsIS,
                                Discount = b.Discount,
                                GenreId = b.GenreId,
                                Name = b.Name,
                                Picture = b.Picture,
                                PublisherId = b.PublisherId,
                                grade = b.grade,
                                pages = b.pages,
                                price = b.price,
                                published = b.published,
                                quantity = b.quantity 
                                }).ToList();
            return books;
        }
        public bool updateBook(int bid) {
            // linq update
            return true;
        }
        public bool deleteBook(int hid) {
            // linq delete
            return true;
        }
        public bool createBook() {
            // linq insert
            return true;
        }
    }
}