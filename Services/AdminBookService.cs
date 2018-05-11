using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;
using System;
namespace TheBookCave.Services {
    public class AdminBookService {
        private BookRepo _bookRepo;
        private ConvertService _convertService;

        public AdminBookService() {
            _bookRepo = new BookRepo();
            _convertService = new ConvertService();
        }

         public List<BookListViewModel> getBook(int id) {
            var book = _bookRepo.getBook(id);
            return book;
        }

        public List<BookListViewModel> getAllBooks() {
            var books = _bookRepo.getAllBooks();

            return books;
        }
        public void updateBook(BookListViewModel b) {
            var book = convertBookListViewModelToBook(b);
            var successfull = _bookRepo.updateBook(book);
        }

        public void updateDetaildBook(BookDetailedListViewModel bd){
            var book = _convertService.bookListViewToEntity(_bookRepo.getBook(bd.Id)).First();
           /* var publisherId = (from p in bd.Publisher
                                where bd.Publisher == p.Name 
                                select p.Id).SingleOrDefault();
            var genreId = ( from g in bd.Genre
                            where bd.Genre == g.GenreEN
                            select g.Id).SingleOrDefault();
            var authorId = ( from a in bd.Authors
                            where bd.Author == a.Name
                            select a.AuthorId).SingleOrDefault(); */
            book.Name = bd.Name;
            book.AuthorId = Int32.Parse(bd.Author);
            book.Picture = bd.Picture;
            book.DetailsIS = bd.DetailsIS;
            book.DetailsEN = bd.DetailsEN;
            book.PublisherId = Int32.Parse(bd.Publisher);
            book.GenreId = Int32.Parse(bd.Genre);
            book.Price = bd.Price;
            book.Discount = bd.Discount;
            book.Pages = bd.Pages;
            book.Quantity = bd.Quantity;
            book.Published = bd.Published;
            _bookRepo.updateBook(book);
        }

        



        public void createBook(BookListViewModel b) {
            var book = convertBookListViewModelToBook(b);
            var successfull = _bookRepo.createBook(book);
        }
        public void removeBook(BookListViewModel b) {
            var book = convertBookListViewModelToBook(b);
            var successfull = _bookRepo.removeBook(book);
        }

        private Book convertBookListViewModelToBook(BookListViewModel b) {
            var book = new Book {
                                AuthorId = b.AuthorId,
                                DetailsEN = b.DetailsEN,
                                DetailsIS = b.DetailsIS,
                                Discount = b.Discount,
                                GenreId = b.GenreId,
                                Grade = b.Grade,
                                Id = b.Id,
                                Name = b.Name,
                                Pages = b.Pages,
                                Picture = b.Picture,
                                Price = b.Price,
                                Published = b.Published,
                                PublisherId = b.PublisherId,
                                Quantity = b.Quantity                                
                                };
            return book;
        }

        public List<BookListViewModel> getSearchResult(string searchString) {
            var books = _bookRepo.getAllBooks();
            var searchResult = (from b in books
                        where b.Name.ToLower().Contains(searchString.ToLower())
                        select new BookListViewModel
                        {
                            AuthorId = b.AuthorId,
                            DetailsEN = b.DetailsEN,
                            DetailsIS = b.DetailsIS,
                            Discount = b.Discount,
                            GenreId = b.GenreId,
                            Grade = b.Grade,
                            Id = b.Id,
                            Name = b.Name,
                            Pages = b.Pages,
                            Picture = b.Picture,
                            Price = b.Price,
                            Published = b.Published,
                            PublisherId = b.PublisherId,
                            Quantity = b.Quantity    
                        }).ToList();

            return searchResult;
        }


    }
}