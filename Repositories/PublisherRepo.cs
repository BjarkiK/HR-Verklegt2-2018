using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class PublisherRepo {
        private DataContext _db;

        public PublisherRepo() {
            _db = new DataContext();
        }
        public List<PublisherListViewModel> getPublisher(int pid) {
            var publisher = (from p in _db.Publishers
                                where p.Id == pid
                                select new PublisherListViewModel {
                                Id = p.Id,
                                Name = p.Name
                                }).ToList();
            return publisher;
        }
        public List<PublisherListViewModel> getAllPublishers() {
            var publishers = (from p in _db.Publishers
                                select new PublisherListViewModel {
                                Id = p.Id,
                                Name = p.Name
                                }).ToList();
            return publishers;
        }
        public bool updatePublisher(int aid) {
            // linq update
            return true;
        }
        public bool deletePublisher(int aid) {
            // linq delete
            return true;
        }
        public bool createPublisher() {
            // linq insert
            return true;
        }
    }
}