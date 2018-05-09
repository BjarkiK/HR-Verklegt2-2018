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


        public User userViewToEntity(UserListViewModel u) {

                var user = new User {
                    Id = u.Id,
                    AccessFailedCount = u.AccessFailedCount,
                    ConcurrencyStamp = u.ConcurrencyStamp,
                    Email = u.Email,
                    EmailConfirmed = u.EmailConfirmed,
                    LockoutEnd = u.LockoutEnd,
                    LockoutEnabled = u.LockoutEnabled,
                    NormalizedEmail = u.NormalizedEmail,
                    NormalizedUserName = u.NormalizedUserName,
                    PasswordHash = u.PasswordHash,
                    PhoneNumber = u.PhoneNumber,
                    PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                    SecurityStamp = u.SecurityStamp,
                    TwoFactorEnabled = u.TwoFactorEnabled,
                    UserName = u.UserName                 
                };
            return user;
        }
    }
}