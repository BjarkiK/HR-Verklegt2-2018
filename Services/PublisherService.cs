using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class PublisherService {
        
        private PublisherRepo _PublisherRepo;
        public PublisherService(){
            _PublisherRepo = new PublisherRepo();
        }
        public List<PublisherListViewModel> getAllPublishers() {
            var Publishers = _PublisherRepo.getAllPublishers();
            // Filter books that are in cart and return
            return Publishers;
        }

    }
}