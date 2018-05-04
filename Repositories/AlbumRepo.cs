using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class AlbumRepo {
        private DataContext _db;

        public AlbumRepo() {
            _db = new DataContext();
        }

        /*public List<AlbumListViewModel> GetAllAlbums() {
            var albums =    (from a in _db.Albums
                            join ar in _db.Artists on a.ArtistId equals ar.Id
                            select new AlbumListViewModel {
                                AlbumId = a.Id,
                                Title = a.Title,
                                Artist = ar.Name,
                                ArtistId = ar.Id,
                                ReleaseYear = a.releaseYear
                            }).ToList();
            return albums;
        }*/
    }
}