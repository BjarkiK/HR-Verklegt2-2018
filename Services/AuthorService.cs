using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AuthorService {
        
        private AuthorRepo _authorRepo;
        public AuthorService(){
            _authorRepo = new AuthorRepo();
        }
        public List<AuthorListViewModel> getAllAuthors() {
            var authors = _authorRepo.getAllAuthors();
            // Filter books that are in cart and return
            return authors;
        }

    }
}