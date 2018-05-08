using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories {
    public class HelpTypeRepo {
        private DataContext _db;

        public HelpTypeRepo() {
            _db = new DataContext();
        }
        public List<HelpTypeListViewModel> getAllTypes() {
            var types = (from typ in _db.HelpType
                            select new HelpTypeListViewModel {
                            Id = typ.Id,
                            TypeEN = typ.TypeEN,
                            TypeIS = typ.TypeIS
                            }).ToList();
            return types;
        }
    }
}