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

         public List<BookListViewModel> getBook(int bookId) {
            var book = _orderRepo.getBook(bookId);

            return book;
        }

        public List<BookListViewModel> getAllBooks() {
            var books = _orderRepo.getAllBooks();

            return books;
        }

         public void createBook(Book book) {
            _orderRepo.createBook(book);
        }

    }
}