using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminBookService {
        private BookRepo _bookRepo;

        public AdminBookService() {
            _bookRepo = new BookRepo();
        }

         public List<BookListViewModel> GetBook(int id) {
            var book = _bookRepo.getBook(id);
            return book;
        }

        public List<BookListViewModel> getAllBooks() {
            var books = _bookRepo.getAllBooks();

            return books;
        }
        public void updateBook(BookListViewModel b) {
            var book = ConvertBookListViewModelToBook(b);
            var successfull = _bookRepo.updateBook(book);
        }

        public void CreateBook(BookListViewModel b) {
            var book = ConvertBookListViewModelToBook(b);
            var successfull = _bookRepo.createBook(book);
        }

        private Book ConvertBookListViewModelToBook(BookListViewModel b) {
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