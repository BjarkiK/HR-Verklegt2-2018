using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AuthorService {
        
        private AuthorRepo _AuthorRepo;
        public AuthorService(){
            _AuthorRepo = new AuthorRepo();
        }
        public List<AuthorListViewModel> getAllAuthors() {
            var authors = _AuthorRepo.getAllAuthors();
            // Filter books that are in cart and return
            return authors;
        }

    }
}