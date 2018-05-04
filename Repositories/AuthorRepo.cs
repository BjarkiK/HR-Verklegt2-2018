using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class AuthorRepo {
        private DataContext _db;

        public AuthorRepo() {
            _db = new DataContext();
        }
        public List<AuthorListViewModel> getAuthor(int aid) {
            var author = (from a in _db.Authors
                                where a.Id == aid
                                select new AuthorListViewModel {
                                AuthorId = a.Id,
                                DateOfBirth = a.DateOfBirth,
                                DescriptionEN = a.DescriptionEN,
                                DescriptionIS = a.DescriptionIS,
                                Name = a.Name
                                }).ToList();
            return author;
        }
        public List<AuthorListViewModel> getAllAuthor(int aid) {
            var authors = (from a in _db.Authors
                                select new AuthorListViewModel {
                                AuthorId = a.Id,
                                DateOfBirth = a.DateOfBirth,
                                DescriptionEN = a.DescriptionEN,
                                DescriptionIS = a.DescriptionIS,
                                Name = a.Name
                                }).ToList();
            return authors;
        }
        public bool updateAuthor(int aid) {
            // linq update
            return true;
        }
        public bool deleteAuthor(int aid) {
            // linq delete
            return true;
        }
        public bool createAuthor() {
            // linq insert
            return true;
        }
    }
}