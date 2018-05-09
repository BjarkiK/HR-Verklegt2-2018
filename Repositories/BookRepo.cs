using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class BookRepo {
        private DataContext _db;

        public BookRepo() {
            _db = new DataContext();
        }
        public List<BookListViewModel> getBook(int id) {
            var book = (from b in _db.Books
                                where b.Id == id
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
                                    NrOfGrades = b.NrOfGrades,
                                    Grade = b.Grade,
                                    Pages = b.Pages,
                                    Price = b.Price,
                                    Published = b.Published,
                                    Quantity = b.Quantity 
                                }).ToList();
            return book;
        }
        public List<BookListViewModel> getAllBooks() {
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
                                    NrOfGrades = b.NrOfGrades,
                                    Grade = b.Grade,
                                    Pages = b.Pages,
                                    Price = b.Price,
                                    Published = b.Published,
                                    Quantity = b.Quantity 
                                }).ToList();
            return books;
        }
        public Book getBookData(int bid) {
            var book = (from b in _db.Books
                        where b.Id == bid
                        select new Book {
                            Id = b.Id,
                            AuthorId = b.AuthorId,
                            DetailsEN = b.DetailsEN,
                            DetailsIS = b.DetailsIS,
                            Discount = b.Discount,
                            GenreId = b.GenreId,
                            Name = b.Name,
                            Picture = b.Picture,
                            PublisherId = b.PublisherId,
                            NrOfGrades = b.NrOfGrades,
                            Grade = b.Grade,
                            Pages = b.Pages,
                            Price = b.Price,
                            Published = b.Published,
                            Quantity = b.Quantity
                        }).SingleOrDefault();
            return book;
        }
        
        public bool deleteBook(int hid) {
            // linq delete
            return true;
        }
        public bool createBook(Book book) {
            _db.Books.Add(book);
            _db.SaveChanges();
            return true;
        }
        public bool updateBook(Book book) {
            _db.Books.Update(book);
            _db.SaveChanges();
            return true;
        }

        public bool removeBook(Book book){
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }
    }
}