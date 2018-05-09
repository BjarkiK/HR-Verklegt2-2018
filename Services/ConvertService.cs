using System.Collections.Generic;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class ConvertService {
    
        public ConvertService() { 
        }
        public List<Book> bookListViewToEntity(List<BookListViewModel> bookList) {
            var books = new List<Book>();
            foreach (var b in bookList) {
                var book = new Book {
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    Picture = b.Picture,
                    Grade = b.Grade,
                    DetailsEN = b.DetailsEN,
                    DetailsIS = b.DetailsIS,
                    Discount = b.Discount,
                    Pages = b.Pages,
                    Quantity = b.Quantity,
                    Published = b.Published,
                    AuthorId = b.AuthorId,
                    GenreId = b.GenreId,
                    PublisherId = b.PublisherId
                };
                books.Add(book);
            }
            return books;
        }

    }
}