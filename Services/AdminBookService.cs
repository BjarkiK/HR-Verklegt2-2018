using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AdminBookService {
        private BookRepo _orderRepo;

        public AdminBookService() {
            _orderRepo = new BookRepo();
        }

         public List<BookListViewModel> GetBook(int id) {
            var book = _orderRepo.getBook(id);
            return book;
        }

        public List<BookListViewModel> getAllBooks() {
            var books = _orderRepo.getAllBooks();

            return books;
        }
        public void updateBook(BookListViewModel b) {
            var book = ConvertBookListViewModelToBook(b);
            var successfull = _orderRepo.updateBook(book);
        }

        public void CreateBook(BookListViewModel b) {
            var book = ConvertBookListViewModelToBook(b);
            var successfull = _orderRepo.createBook(book);
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

    }
}