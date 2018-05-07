using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class GenreService {
        
        private GenreRepo _GenreRepo;
        public GenreService(){
            _GenreRepo = new GenreRepo();
        }
        public List<GenreListViewModel> getAllGenres() {
            var Genres = _GenreRepo.getAllGenre();
            // Filter books that are in cart and return
            return Genres;
        }

    }
}