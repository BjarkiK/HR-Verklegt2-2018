using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class GenreRepo {
        private DataContext _db;

        public GenreRepo() {
            _db = new DataContext();
        }
        public List<GenreListViewModel> getGenre(int gid) {
            var genre = (from gen in _db.Genre
                                where gen.Id == gid
                                select new GenreListViewModel {
                                Id = gen.Id,
                                GenreEN = gen.GenreEN,
                                GenreIS = gen.GenreIS
                                }).ToList();
            return genre;
        }
        public List<GenreListViewModel> getAllGenres() {
            var genres = (from gen in _db.Genre
                                select new GenreListViewModel {
                                Id = gen.Id,
                                GenreEN = gen.GenreEN,
                                GenreIS = gen.GenreIS
                                }).ToList();
            return genres;
        }
        public bool updateGenre(int gid) {
            // linq update
            return true;
        }
        public bool deleteGenre(int gid) {
            // linq delete
            return true;
        }
        public bool createGenre() {
            // linq insert
            return true;
        }
    }
}