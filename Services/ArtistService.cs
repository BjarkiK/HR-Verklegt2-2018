using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services {
    public class ArtistService {
        private ArtistRepo _artistRepo;

        public ArtistService() {
            _artistRepo = new ArtistRepo();
        }

        /*public List<ArtistListViewModel> GetAllArtists() {
            //var artists = _artistRepo.GetAllArtists();

            return null;
        }*/
    }
}