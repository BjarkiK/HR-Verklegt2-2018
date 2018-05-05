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

         public List<BookListViewModel> GetBook(int bookId) {
            var book = _orderRepo.GetBook(bookId);

            return book;
        }

        public List<BookListViewModel> GetAllBooks() {
            var books = _orderRepo.GetAllBooks();

            return books;
        }

         public void CreateBook(Book book) {
            _orderRepo.createBook(book);
        }

    }
}