using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class AlbumService {
        private AlbumRepo _albumRepo;

        public AlbumService() {
            _albumRepo = new AlbumRepo();
        }

        /*public List<AlbumListViewModel> GetAllAlbums() {
            var albums = _albumRepo.GetAllAlbums();

            return albums;
        }*/
    }
}