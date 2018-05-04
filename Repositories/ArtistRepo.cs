using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewyModels;

namespace TheBookCave.Repositories {
    public class ArtistRepo {

        private DataContext _db; 

        public ArtistRepo() {
            _db = new DataContext();
        }
        public List<ArtistListViewModel> GetAllArtists() {
            /*var artists =   (from a in _db.Artists
                            select new ArtistListViewModel {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList();
            return artists;*/
            return null;
        }
    }
}