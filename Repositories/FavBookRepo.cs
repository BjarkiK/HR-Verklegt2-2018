using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Data.EntityModels;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class FavBookRepo {
        private DataContext _db;

        public FavBookRepo() {
            _db = new DataContext();
        }

        
        public List<FavBook> getAllFavBooks() {
            var FavBooks = (from fb in _db.FavBooks
                                select fb).ToList();
            return FavBooks;
        }

        public void addFavoriteBook(FavBook fb) {
            _db.Add(fb);
            _db.SaveChanges();
        }

        public bool removeFavBook(FavBook fb){
            _db.FavBooks.Remove(fb);
            _db.SaveChanges();
            return true;
        }
    }
}